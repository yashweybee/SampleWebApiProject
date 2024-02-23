using Microsoft.AspNetCore.Mvc;
using SampleBLL.Interfaces;
using SampleDAL.DbModels;
using SampleDAL.Repository;
using SampleDAL.ViewModels;
using AutoMapper;

namespace SampleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : BaseApiController<CategoriesController>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ILogger<CategoriesController> logger, ICategoryService categoryService, IMapper mapper)
            : base(logger)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get list of all categories from db
        /// </summary>
        /// <returns>List of all categories</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VMCategory>>> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        /// <summary>
        /// Get category based on given id
        /// </summary>
        /// <param name="id">id passed in request body</param>
        /// <returns>Single category data if found else 404 Not Found</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        /// <summary>
        /// Add new category name in the DB table.
        /// </summary>
        /// <param name="vmCategory">Inclueds only name enterd in request </param>
        /// <returns> Returns added category information </returns>
        /// 
        [HttpPost]
        public async Task<ActionResult<VMCategory>> CreateCategory(VMCategory vmCategory)
        {
            // Map CategoryViewModel to Category
            var category = _mapper.Map<Category>(vmCategory);
            var createdCategory = await _categoryService.AddAsync(category);
            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.CategoryId }, createdCategory);
        }



        /// <summary>
        /// Get category from the table using [id] and then assign new name, update the name of category
        /// </summary>
        /// <param name="id"> id of the perticuler category </param>
        /// <param name="vmCategory"> name entered in request </param>
        /// <returns> Returns updated category information</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, VMCategory vmCategory)
        {
            var editedCategory = new Category
            {
                CategoryId = id,
                Name = vmCategory.Name,
            };
            // Map CategoryViewModel to Category
            var category = _mapper.Map<Category>(editedCategory);

            await _categoryService.UpdateAsync(category);

            return NoContent();
        }



        /// <summary>
        /// First check if the category is present or not then,
        /// Deletes category from table based on given id
        /// </summary>
        /// <param name="id"> id passed in request body </param>
        /// <returns> 
        /// if not found any category -> 404 Not Found, else -> 204 no content
        ///</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _categoryService.Remove(category);

            return NoContent();
        }
    }
}
