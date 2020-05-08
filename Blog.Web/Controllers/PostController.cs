using System.Threading.Tasks;
using Blog.Application.Interfaces;
using Blog.Application.ViewModels.Comment;
using Blog.Application.ViewModels.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly ICommentService _commentService;
        private readonly ICurrentUserService _currentUserService;
        private readonly ICategoryService _categoryService;

        public PostController(IPostService postService,
            ICommentService commentService,
            ICurrentUserService currentUserService,
            ICategoryService categoryService)
        {
            _postService = postService;
            _commentService = commentService;
            _currentUserService = currentUserService;
            _categoryService = categoryService;
        }

        [Route("/post/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var post = await _postService.GetPostById(id);
            var userId = await _currentUserService.GetUserId();
            ViewData["currentUser"] = userId;

            return View(post);
        }

        [Authorize]
        public async Task<IActionResult> NewPost()
        {
            var model = new NewPostViewModel
            {
                Categories = await _categoryService.GetCategories()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddNewPost(NewPostViewModel model)
        {
            model.UserId = await _currentUserService.GetUserId();

            var postId = await _postService.CreatePost(model);

            return RedirectToAction(nameof(Index), new { id = postId });
        }

        [Authorize]
        public async Task<IActionResult> NewComment(int postId)
        {
            var model = new CommentViewModel
            {
                PostId = postId
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> NewComment(NewCommentViewModel model)
        {
            model.UserId = await _currentUserService.GetUserId();

            var result = await _commentService.AddComment(model);

            return RedirectToAction(nameof(Index), new { id = model.PostId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Like(int postId, string userId)
        {
            await _postService.LikePost(postId, userId);

            return RedirectToAction(nameof(Index), new { id = postId });
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DisLike(int postId, string userId)
        {
            await _postService.DisLikePost(postId, userId);

            return RedirectToAction(nameof(Index), new { id = postId });
        }
    }
}