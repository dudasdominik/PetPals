using Microsoft.AspNetCore.Mvc;
using PetPals.Models.DTOs;

namespace PetPals.Controllers;
[ApiController]
[Route("/api/v1/genders/")]
public class GenderController : ControllerBase
{
    [HttpGet]
    public List<GenderDTO> GetAllGenders()
    {
        return GenderDTO.GetAllGenders();
    }
}