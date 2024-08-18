using HotelReservationApi.DTOs.Pictures;
using HotelReservationApi.Services.PictureSrv;
using HotelReservationApi.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PictureController : ControllerBase
    {
        IPictureService _pictureService;
        public PictureController(IPictureService pictureService)
        {
            this._pictureService = pictureService;
        }

        [HttpPost]

        public async Task<ActionResult<ResultViewModel>> AddPicture(PicturesCreateDTO picture)
        {
            if (!ModelState.IsValid) { return BadRequest(new ResultViewModel() { StatusCode = 400, Data = ModelState }); };
            return Ok(await _pictureService.AddPicture( picture));
        }
    }
}
