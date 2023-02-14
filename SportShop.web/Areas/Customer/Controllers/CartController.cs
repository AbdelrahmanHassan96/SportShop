using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportShop.DataAccess.Repositories;
using SportShop.Models;
using System.Security.Claims;

namespace SportShop.web.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize]
        public IActionResult CartView()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var UserId = claims.Value;
            var cart = _unitOfWork.cart.GetT(c => c.ApplicationUserId == UserId);
            cart.CartLines = _unitOfWork.cartLine.GetAll(l => l.CartId == cart.Id, include: "Product").ToList();
            //var cartLines = _unitOfWork.cartLine.GetAll(l => l.CartId == cart.Id, include: "Product");
            return View(cart);
        }
        [Authorize]
        public PartialViewResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var UserId = claims.Value;
            var cart = _unitOfWork.cart.GetT(c => c.ApplicationUserId == UserId, include: "CartLines");
            return PartialView(cart.Count);
        }

        [Authorize]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var UserId = claims.Value;
            var cart = _unitOfWork.cart.GetT(c => c.ApplicationUserId == UserId, include: "CartLines");
            if (quantity < 0)
                quantity = 1;
            if (quantity > 10)
                quantity = 10;
            if (cart == null)
            {
                cart = new Cart()
                {
                    ApplicationUserId = UserId
                };
                _unitOfWork.cart.Add(cart);
            }

            var cartline = cart.CartLines.FirstOrDefault(l => l.ProductId == productId);
            var product = _unitOfWork.product.GetT(p => p.Id == productId);
            if (cartline == null)
            {
                if (quantity <= 0)
                    quantity = 1;
                cartline = new CartLine
                {
                    CartId = cart.Id,
                    cart = cart,
                    ProductId = productId,
                    Quantity = quantity,
                    LinePrice = quantity * product.UnitPrice,
                    Product = product,
                };
                cart.CartLines.Add(cartline);
            }
            else
            {
                cartline.Quantity += quantity;

                if (cartline.Quantity > 10)
                    cartline.Quantity = 10;

                cartline.LinePrice= cartline.Quantity * product.UnitPrice;
            }
            
            cart.Total = cart.CartLines.Sum(l=>l.LinePrice);
            cart.Count = cart.CartLines.Count();
            _unitOfWork.Save();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public IActionResult RemoveItem (int productId)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var UserId = claims.Value;
            var cart = _unitOfWork.cart.GetT(c => c.ApplicationUserId == UserId, include: "CartLines");
            var cartline = cart.CartLines.FirstOrDefault(l => l.ProductId == productId);

            if (cartline != null)
            {
                cart.CartLines.Remove(cartline);
                cart.Total = cart.CartLines.Sum(l=>l.LinePrice);
                cart.Count = cart.CartLines.Count();
                _unitOfWork.Save();
            }
            return RedirectToAction("CartView", "Cart");
        }

        [Authorize]
        public IActionResult UpdateQuantity(int productId, int quantity = 1)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var UserId = claims.Value;
            var cart = _unitOfWork.cart.GetT(c => c.ApplicationUserId == UserId, include: "CartLines");
            if (quantity < 0)
                quantity = 1;
            if (quantity > 10)
                quantity = 10;
            if (cart == null)
            {
                cart = new Cart()
                {
                    ApplicationUserId = UserId
                };
                _unitOfWork.cart.Add(cart);
            }

            var cartline = cart.CartLines.FirstOrDefault(l => l.ProductId == productId);
            var product = _unitOfWork.product.GetT(p => p.Id == productId);
            if (cartline == null)
            {
                if (quantity <= 0)
                    quantity = 1;
                cartline = new CartLine
                {
                    CartId = cart.Id,
                    cart = cart,
                    ProductId = productId,
                    Quantity = quantity,
                    LinePrice = quantity * product.UnitPrice,
                    Product = product,
                };
                cart.CartLines.Add(cartline);
            }
            else
            {
                cartline.Quantity = quantity;

                if (cartline.Quantity > 10)
                    cartline.Quantity = 10;

                cartline.LinePrice = cartline.Quantity * product.UnitPrice;
            }

            cart.Total = cart.CartLines.Sum(l => l.LinePrice);
            cart.Count = cart.CartLines.Count();
            _unitOfWork.Save();
            return RedirectToAction("CartView", "Cart");
        }

    }
}
