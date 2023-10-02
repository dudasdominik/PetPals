using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetPals.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TagModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "chatroom",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chatroom", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "message",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecipientId = table.Column<Guid>(type: "uuid", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    ChatRoomModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_message", x => x.Id);
                    table.ForeignKey(
                        name: "FK_message_chatroom_ChatRoomModelId",
                        column: x => x.ChatRoomModelId,
                        principalTable: "chatroom",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NotificationType = table.Column<int>(type: "integer", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    LinkToItem = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "photo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    EntityType = table.Column<int>(type: "integer", nullable: false),
                    PostModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    TagName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ProfilePictureId = table.Column<Guid>(type: "uuid", nullable: false),
                    BannerPictureId = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    isVerified = table.Column<bool>(type: "boolean", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    ChatRoomModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_chatroom_ChatRoomModelId",
                        column: x => x.ChatRoomModelId,
                        principalTable: "chatroom",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_user_photo_BannerPictureId",
                        column: x => x.BannerPictureId,
                        principalTable: "photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_photo_ProfilePictureId",
                        column: x => x.ProfilePictureId,
                        principalTable: "photo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "post",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Views = table.Column<int>(type: "integer", nullable: false),
                    MessageModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_post_message_MessageModelId",
                        column: x => x.MessageModelId,
                        principalTable: "message",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_post_user_SenderId",
                        column: x => x.SenderId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserModelUserModel",
                columns: table => new
                {
                    FollowersId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowingsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModelUserModel", x => new { x.FollowersId, x.FollowingsId });
                    table.ForeignKey(
                        name: "FK_UserModelUserModel_user_FollowersId",
                        column: x => x.FollowersId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserModelUserModel_user_FollowingsId",
                        column: x => x.FollowingsId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ToPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentCommentId = table.Column<Guid>(type: "uuid", nullable: false),
                    IsReplyTo = table.Column<bool>(type: "boolean", nullable: false),
                    CommentModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comment_comment_CommentModelId",
                        column: x => x.CommentModelId,
                        principalTable: "comment",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_comment_post_ToPostId",
                        column: x => x.ToPostId,
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comment_user_SenderId",
                        column: x => x.SenderId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagModel",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uuid", nullable: false),
                    TagId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagModel", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagModel_post_PostId",
                        column: x => x.PostId,
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagModel_TagModel_TagId",
                        column: x => x.TagId,
                        principalTable: "TagModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostUserLikes",
                columns: table => new
                {
                    LikedPostsId = table.Column<Guid>(type: "uuid", nullable: false),
                    LikesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserLikes", x => new { x.LikedPostsId, x.LikesId });
                    table.ForeignKey(
                        name: "FK_PostUserLikes_post_LikedPostsId",
                        column: x => x.LikedPostsId,
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserLikes_user_LikesId",
                        column: x => x.LikesId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostUserSaves",
                columns: table => new
                {
                    SavedPostsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SavesId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostUserSaves", x => new { x.SavedPostsId, x.SavesId });
                    table.ForeignKey(
                        name: "FK_PostUserSaves_post_SavedPostsId",
                        column: x => x.SavedPostsId,
                        principalTable: "post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostUserSaves_user_SavesId",
                        column: x => x.SavesId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_chatroom_CreatedById",
                table: "chatroom",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_comment_CommentModelId",
                table: "comment",
                column: "CommentModelId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_SenderId",
                table: "comment",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_comment_ToPostId",
                table: "comment",
                column: "ToPostId");

            migrationBuilder.CreateIndex(
                name: "IX_message_ChatRoomModelId",
                table: "message",
                column: "ChatRoomModelId");

            migrationBuilder.CreateIndex(
                name: "IX_message_RecipientId",
                table: "message",
                column: "RecipientId");

            migrationBuilder.CreateIndex(
                name: "IX_message_SenderId",
                table: "message",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_notification_SenderId",
                table: "notification",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_photo_PostModelId",
                table: "photo",
                column: "PostModelId");

            migrationBuilder.CreateIndex(
                name: "IX_post_MessageModelId",
                table: "post",
                column: "MessageModelId");

            migrationBuilder.CreateIndex(
                name: "IX_post_SenderId",
                table: "post",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagModel_TagId",
                table: "PostTagModel",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserLikes_LikesId",
                table: "PostUserLikes",
                column: "LikesId");

            migrationBuilder.CreateIndex(
                name: "IX_PostUserSaves_SavesId",
                table: "PostUserSaves",
                column: "SavesId");

            migrationBuilder.CreateIndex(
                name: "IX_user_BannerPictureId",
                table: "user",
                column: "BannerPictureId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ChatRoomModelId",
                table: "user",
                column: "ChatRoomModelId");

            migrationBuilder.CreateIndex(
                name: "IX_user_ProfilePictureId",
                table: "user",
                column: "ProfilePictureId");

            migrationBuilder.CreateIndex(
                name: "IX_UserModelUserModel_FollowingsId",
                table: "UserModelUserModel",
                column: "FollowingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_chatroom_user_CreatedById",
                table: "chatroom",
                column: "CreatedById",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_user_RecipientId",
                table: "message",
                column: "RecipientId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_message_user_SenderId",
                table: "message",
                column: "SenderId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_notification_user_SenderId",
                table: "notification",
                column: "SenderId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_photo_post_PostModelId",
                table: "photo",
                column: "PostModelId",
                principalTable: "post",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_photo_post_PostModelId",
                table: "photo");

            migrationBuilder.DropForeignKey(
                name: "FK_chatroom_user_CreatedById",
                table: "chatroom");

            migrationBuilder.DropTable(
                name: "comment");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "PostTagModel");

            migrationBuilder.DropTable(
                name: "PostUserLikes");

            migrationBuilder.DropTable(
                name: "PostUserSaves");

            migrationBuilder.DropTable(
                name: "UserModelUserModel");

            migrationBuilder.DropTable(
                name: "TagModel");

            migrationBuilder.DropTable(
                name: "post");

            migrationBuilder.DropTable(
                name: "message");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "chatroom");

            migrationBuilder.DropTable(
                name: "photo");
        }
    }
}
