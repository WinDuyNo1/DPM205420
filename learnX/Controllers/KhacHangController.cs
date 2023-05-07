using AutoMapper;
using Infrastructure.Entities;
using Infrastructure.Service;
using learnX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace learnX.Controllers
{
    public class KhachangController : Controller
    {
        private readonly IKhachHangService KhachhangService;
        private readonly IMapper mapper;
        public KhachangController(IKhachHangService KhachhangService, IMapper mapper)
        {
            this.KhachhangService = KhachhangService;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(KhachhangService.GetKhachHang());
        }

        public IActionResult AddOrEdit(int id = 0)
        {
            KhachHangViewModel data = new KhachHangViewModel();
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI TÀI KHOẢN" : "CẬP NHẬT TÀI KHOẢN";

            if (id != 0)
            {
                KhachHang res = KhachhangService.GetKhachHang(id);
                data = mapper.Map<KhachHangViewModel>(res);
                if (data == null)
                {
                    return NotFound();
                }
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, KhachHangViewModel data)
        {
            ViewBag.RenderedHtmlTitle = id == 0 ? "THÊM MỚI TÀI KHOẢN" : "CẬP NHẬT TÀI KHOẢN";

            if (ModelState.IsValid)
            {
                try
                {
                    KhachHang res = mapper.Map<KhachHang>(data);
                    if (id != 0)
                    {
                        KhachhangService.UpdateKhachHang(res);
                    }
                    else
                    {
                        
                        KhachhangService.InsertKhachHang(res);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction("Index", "KhachHang");
            }

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            KhachHang res = KhachhangService.GetKhachHang(id);
            KhachhangService.DeleteKhachHang(res);

            return RedirectToAction("Index", "KhachHang");
        }
    }
}
