using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BBH.BOS.Web.Controllers
{
    public class PagingController : Controller
    {
        // GET: Paging
        public PartialViewResult Index(string p)
        {
            StringBuilder builder = new StringBuilder();
            int pageSize = 10, page = 1;

            try
            {
                if (p != null && p != "")
                {
                    page = int.Parse(p);
                }
            }
            catch
            {

            }
            try
            {
                pageSize = int.Parse(ConfigurationManager.AppSettings["NumberRecordPage"]);
            }
            catch
            {

            }
            string linkPage = "", nextLink = "", previewLink = "", firstLink = "", lastLink = "";
            firstLink = "?p=1";
            if (page <= 1)
            {
                previewLink = "?p=1";
            }
            else
            {
                previewLink = "?p=" + (page - 1).ToString();
            }

            builder.Append("<ul id=\"ulPaging\" class=\"pagination pagination-centered\">");

            int pagerank = 10;
            int next = 10;
            int prev = 1;


            if (TempData["TotalRecord"] != null)
            {
                int totalRecore = (int)TempData["TotalRecord"];
                int totalPage = totalRecore / pageSize;
                int balance = totalRecore % pageSize;
                if (balance != 0)
                {
                    totalPage += 1;
                }
                if (page >= totalPage)
                {
                    nextLink = "?p=" + totalPage.ToString();
                }
                else
                {
                    nextLink = "?p=" + (page + 1).ToString();
                }
                int currentPage = page;
                var m = 1;
                if (totalPage > 10)
                {
                    if (page > pagerank + 1)
                    {
                        next = (page + pagerank) - 1;
                        m = page - pagerank;
                    }
                    if (page <= pagerank)
                    {
                        prev = (page - pagerank);
                        m = 1;
                    }
                    if (next > totalPage)
                    {
                        next = totalPage;
                    }
                    if (prev < 1)
                    {
                        prev = 1;
                    }
                }
                else
                {
                    next = totalPage;
                    prev = 1;
                }
                lastLink = "?p=" + totalPage;
                if (totalPage > 1)
                {
                    if (currentPage > 1)
                    {
                        // builder.Append("<li><a href=\"" + firstLink + "\"><i class=\"fa fa-angle-double-left\"></i></a></li>");
                        builder.Append("<li >");
                        builder.Append("<a href=\"" + previewLink + "\" class=\"page-link waves-effect waves-effect\" aria-label=\"Prev\">Prev</a>");

                        builder.Append(" </li>");
                    }
                }

                if (totalPage > 1)
                {

                    for (; m <= next; m++)
                    {
                        linkPage = "?p=" + m;
                        if (m == currentPage)
                        {
                            builder.Append("<li class=\"active\"><a href=\"" + linkPage + "\" >" + m + "</a></li>");
                        }
                        else
                        {
                            builder.Append("<li ><a href=\"" + linkPage + "\" >" + m + "</a></li>");

                            //if (m < currentPage)
                            //{
                            //    builder.Append("<li class=\"page-item\"><a href=\"" + linkPage + "\" class=\"page-link waves-effect waves-effect\">" + m + "</a></li>");
                            //}
                            //else
                            //{
                            //    builder.Append("<li><a rel=\"next\" href=\"" + linkPage + "\">" + m + "</a></li>");
                            //}
                        }
                    }
                }

                if (totalPage > 1)
                {
                    if (currentPage < totalPage)
                    {
                        builder.Append(" <li >");
                        builder.Append("<a href=\"" + nextLink + "\" class=\"page-link waves-effect waves-effect\" aria-label=\"Next\">Next</a>");
                        builder.Append("</li>");
                        //.Append("<li><a href=\"" + lastLink + "\"><i class=\"fa fa-angle-double-right\"></i></a></li>");
                    }
                }
            }


            builder.Append("</ul>");


            ViewData["Paging"] = builder.ToString();
            return PartialView();
        }
    }
}