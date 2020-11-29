using ASPNET.DTO;
using ASPNET.DTO.VM;
using AspNetdbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNET.BLL
{
    public class PostBLL : IPost
    {
        private readonly AspContext _aspContext;
        public PostBLL(AspContext aspContext)
        {
            _aspContext = aspContext;
        }

        public async Task<Post> AddPost(Post post)
        {
            try
            {
                var res = await _aspContext.Post.AddAsync(post);
                await _aspContext.SaveChangesAsync();
                return res.Entity;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<object> GetUserPostDetails(PostFilterPagination postFilter)
        {



            PaginationResponse paginationResponse = new PaginationResponse();

            try
            {
                List<PostDataVM> lstVMGroupData = new List<PostDataVM>();
                PostDataVM vMGroupData = new PostDataVM();

                if (string.IsNullOrEmpty(postFilter.postFilter.User))
                {

                    var res = await _aspContext.Post.Select(b => new Post()
                    {

                        Comments = b.Comments,
                        NumberOfComments = b.Comments.Count,
                        CreatedBy = b.CreatedBy,
                        CreatedTime = DateTime.UtcNow,
                        PostContent = b.PostContent,
                        PostID = b.PostID,


                    }).ToListAsync();

                    foreach (var item in res)
                    {
                        foreach (Comments items in item.Comments)
                        {
                            var vote = await _aspContext.LikeOrDisLikes.Where(p => p.CommentsID == items.CommentsID).ToListAsync();
                            if (vote != null)
                            {
                                items.NumberOfLike = vote.Count(p => p.CommentsID == items.CommentsID && p.LikeORDislike == true);
                                items.NumberOfLike = vote.Count(p => p.CommentsID == items.CommentsID && p.LikeORDislike == false);
                            }

                        }

                    }
                    postFilter.Pagination.totalItems = res.Count;
                    paginationResponse.Data = res.Skip((postFilter.Pagination.currentPage - 1) * postFilter.Pagination.itemsPerPage)
                                .Take(postFilter.Pagination.itemsPerPage).GroupBy(p => p.PostID).ToList();
                    paginationResponse.Pagination = postFilter.Pagination;



                }
                else
                {
                    var res = await _aspContext.Post.Where(b => b.PostContent.Equals(postFilter.postFilter.User)).Select(b => new Post()
                    {

                        Comments = b.Comments,
                        NumberOfComments = b.Comments.Count,
                        CreatedBy = b.CreatedBy,
                        CreatedTime = DateTime.UtcNow,
                        PostContent = b.PostContent,
                        PostID = b.PostID,

                    }).ToListAsync();

                    foreach (var item in res)
                    {
                        foreach (Comments items in item.Comments)
                        {

                            var vote = _aspContext.LikeOrDisLikes.Where(p => p.CommentsID == items.CommentsID).ToList();
                            if (vote != null)
                            {


                                items.NumberOfLike = vote.Count(p => p.CommentsID == items.CommentsID && p.LikeORDislike == true);
                                items.NumberOfLike = vote.Count(p => p.CommentsID == items.CommentsID && p.LikeORDislike == false);
                            }

                        }

                    }
                    postFilter.Pagination.totalItems = res.Count;
                    paginationResponse.Data = res.Skip((postFilter.Pagination.currentPage - 1) * postFilter.Pagination.itemsPerPage)
                                .Take(postFilter.Pagination.itemsPerPage).GroupBy(p => p.PostID).ToList();
                    paginationResponse.Pagination = postFilter.Pagination;



                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return paginationResponse;

        }




    }
    public interface IPost
    {
        Task<Post> AddPost(Post post);
        Task<object> GetUserPostDetails(PostFilterPagination postFilter);


    }
}
