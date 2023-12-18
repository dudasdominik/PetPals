#!/bin/bash
set -e

# PostgreSQL connection parameters
export PG_USER="root"
export PG_PASSWORD="root"
export PG_HOST="localhost"
export PG_PORT="3254"
export PG_DATABASE="PetPals"

fill_database_with_data() {
  export PGPASSWORD="$PG_PASSWORD"
  psql -h "$PG_HOST" -p "$PG_PORT" -U "$PG_USER" -d "$PG_DATABASE" -f "populate.sql"
}

# Check if Docker Compose is already running
if docker-compose ps | grep -q "Up"; then
  echo "Docker Compose is already running."
else
  # Start the Docker Compose.
  docker-compose up -d
  echo "Docker Compose started."
fi

# Function to check if PostgreSQL is ready
wait_for_postgres() {
    echo "Waiting for PostgreSQL to start..."
    until PGPASSWORD="$PG_PASSWORD" pg_isready -h "$PG_HOST" -p "$PG_PORT"; do
        echo "PostgreSQL not yet ready. Retrying..."
        sleep 1
    done
    dotnet ef database update
    echo "PostgreSQL is ready!"
}

# Wait for PostgreSQL to start
wait_for_postgres

# Database initialization
export PGPASSWORD="$PG_PASSWORD"
if psql -h "$PG_HOST" -p "$PG_PORT" -U "$PG_USER" -d "$PG_DATABASE" -c '\q' 2>/dev/null; then
  sleep 10
  fill_database_with_data
  sleep 10
else
  echo "Something"
fi

# Run other setup tasks if needed

echo "PostgreSQL initialization complete."

# Wait for 30 seconds before exiting
echo "Waiting for 30 seconds before exiting..."
sleep 30
echo "Exiting."
