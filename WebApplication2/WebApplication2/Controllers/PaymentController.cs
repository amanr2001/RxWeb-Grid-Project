using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Asn1.X509;
using Razorpay.Api;
using WebApplication2.Dto;
using WebApplication2.Interfaces;
using WebApplication2.Models;
using WebApplication2.Service;
using IronPdf;
using Amazon;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;
using System;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly Razorpayservice _razorpay;
        private readonly MiniprojectContext _context;
        private readonly Icity _city;
        private readonly Icar _cars;
        private readonly Iobject _object;
        private readonly IobjType _objtype;
        private readonly Iimage _img;
        private readonly Iuser _user;
        private readonly Ioutlet _outlet;
        private readonly Iorder _order;
        private readonly Iorderitem _orderitem;
        private readonly Ipayment _payment;
        private readonly Invoiceservice _invoiceserv;

        public PaymentController(Razorpayservice razorpayservice,Invoiceservice invoice,MiniprojectContext context,Ipayment ipayment, Icity city, Icar icar, Iobject iobject, IobjType iobjType, Iimage iimage, Iuser iuser, Ioutlet ioutlet, Iorder order, Iorderitem iorderitem)
        {
            _razorpay = razorpayservice;
            _context = context;
            _city = city;
            _cars = icar;
            _object = iobject;
            _objtype = iobjType;
            _img = iimage;
            _user = iuser;
            _outlet = ioutlet;
            _order = order;
            _orderitem = iorderitem;
            _payment = ipayment;
            _invoiceserv = invoice;
        }

        [HttpPost]
        [Route("api/payments/create-order")]
        public IActionResult CreateOrder([FromBody] CreateOrderRequestDTO model)
        {
            // Validate and process input parameters

            //var razorpayService = new Razorpayservice();

            var orderId = _razorpay.CreateOrder(model.Amount, model.Currency, model.Receipt);
           
            return Ok(new { OrderId = orderId });
        }

       


        [HttpPost("paymentdata")]
        public async Task<IActionResult> paymdata([FromBody] orderpaymentDTO orderpay)
        {
            try
            {
                string html;
                var resp =await  _razorpay.VerifyPaymentSignature(orderpay.paymentId);
            if (resp != null)
            {
                Models.Payment payment = new Models.Payment();
                payment.Paymentstatus = resp.Status.ToString();
                payment.Paymentamount = resp.amount;
                payment.Paymentmethod = resp.paymentmethod;
                payment.Paymentdatetime = resp.time;
                payment.CreatedBy = orderpay.userid;
                payment.ModifiedBy= orderpay.userid;
                payment.CreatedDate= DateTime.Now;
                payment.ModifiedDate= DateTime.Now;
                payment.Orderitem = orderpay.itemid;
                    var _ord = _orderitem.GetAll();
                var orditem = _ord.FirstOrDefault(x=>x.Orderitem1==orderpay.itemid);
                    if (orditem != null)
                    {
                        var c = _cars.GetAll();
                        var car = c.FirstOrDefault(x => x.Carid == orditem.Carid);
                       var orders = _order.GetAll();
                        var ord = orders.FirstOrDefault(x=>x.Orderid==orditem.Orderid);
                        if(ord != null)
                        {
                            Random random = new Random();
                            int x = random.Next(1000, 9999);

                            var u = _user.GetAll();
                            var user = u.FirstOrDefault(x => x.Userid == ord.Userid);
                            var fs = new FileStream("./Templat/Invoice.html", FileMode.Open, FileAccess.Read);
                            var sr = new StreamReader(fs);
                            var replacements = new Dictionary<string, string>
                            {
                                { "##name##", user.Username },
                                { "##Email##",user.Useremail  },
                                { "##invoice##",x.ToString()  },
                                { "##carmodel##", car.Carmodel },
                                { "##carbrand##", car.Carbrand },
                                { "##paymentmethod##", resp.paymentmethod },
                                { "##paymentamount##", payment.Paymentamount.ToString() },
                                { "##paymenttime##", payment.Paymentdatetime.Value.ToShortDateString() },


                            };
                             html =  sr.ReadToEnd() ;
                            
                            html = ReplaceAllOccurrences(html, replacements);
                            fs.Close();
                            var zx = new FileStream("./Templat/InvoiceEmailTemplate.html", FileMode.Open, FileAccess.Read);
                            var rs = new StreamReader(zx);
                            var invoiceEmailTemphtml = rs.ReadToEnd().Replace("##name##", user.Username);
                            fs.Close();
                            var bod = $"Dear {user.Username}  Congratulations on your recent purchase from Spinny Car Hub! You are now the proud owner of a beautiful car. We want to express our heartfelt thanks for choosing Spinny Car Hub for your car buying experience.We strive to provide the best quality and service to our customers, and we are delighted to have you as a valued member of the Spinny community.If you have any questions or need assistance with your car, our support team is here to help.Please feel free to contact us at support@spinny.com.";
                            //_invoiceserv.GeneratePdf(html);
                            byte[] pdfBytes = _invoiceserv.GeneratePdfFromHtml(html);
                            var fileName = "generated_file.pdf";
                            _invoiceserv.sendmail(pdfBytes, user.Useremail, "Spinny Cars", bod);
                        }
                    }
                _context.Payments.Add(payment); 
                _context.SaveChanges();

            }
            return Ok(resp);
            }
            catch(Exception ex)
            {
                    return BadRequest(ex.Message);
            }
        }

        private string ReplaceAllOccurrences(string originalString, Dictionary<string, string> replacements)
        {
            // Loop through each replacement pair and perform the replacements
            foreach (var replacement in replacements)
            {
                originalString = originalString.Replace(replacement.Key, replacement.Value);
            }

            return originalString;
        }
        [HttpPut("updcarstatus/{id}")]
        public async Task<IActionResult> updcarstat(int id)
        {
            try
            {

            var c = _context.Cars.FirstOrDefault(x=>x.Carid == id);
            if (c != null)
            {

            c.Status = 8;
            _context.SaveChanges();
            return Ok(c);   
            }
            else
            {
                return BadRequest("car not found");
            }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            

        }


        [HttpGet("paymentportal")]
        public async Task<IActionResult> paymentdata()
        {
            try
            {

            var order = _order.GetAll();
            var orderitem = _orderitem.GetAll();
            var car = _cars.GetAll();
            var pay = _payment.GetAll();
            var res = (from x in pay
                       //where x.CreatedBy == id
                       select new
                       {
                           x.Paymentid,
                           x.Paymentstatus,
                           x.Paymentamount,
                           x.Paymentmethod,
                           x.Paymentdatetime, x.Orderitem,
                           x.CreatedBy,x.CreatedDate, x.ModifiedBy,x.ModifiedDate
                       });

            return Ok (res);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            

            
        }

        [HttpGet("getuserdataaa")]
        public async Task<IActionResult> getuserdata()
        {
            var user = _user.GetAll();
            var ans = (from u in user
                       select u.Username);
            return Ok(ans);
        }
    }
}
