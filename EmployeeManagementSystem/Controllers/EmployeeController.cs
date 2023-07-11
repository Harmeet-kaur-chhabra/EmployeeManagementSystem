using AutoMapper;
using Azure;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Model;
using EmployeeManagementSystem.Model.DTO.Employee;
using EmployeeManagementSystem.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EmployeeManagementSystem.Controllers
{
    [Route("api/Employee")]
    [Controller]
    public class EmployeeController : ControllerBase
    {
        //Dependency Injection
        private readonly IEmployeeRepository _dbEmployee;
        private readonly IDepartmentRepository _dbDepartment;
        private readonly IDesignationRepository _dbDesignation;
        private readonly IMapper _mapper;
        protected ApiResponse _response;
        public EmployeeController(IEmployeeRepository dbEmployee, IMapper mapper, IDepartmentRepository dbDepartment, IDesignationRepository dbDesignation)  
        {
            _dbEmployee = dbEmployee;
            _mapper = mapper;
            this._response = new();
            _dbDepartment = dbDepartment;
            _dbDesignation = dbDesignation;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse>> GetEmployees()
        {
            try
            {
                IEnumerable<Employee> employeeList = await _dbEmployee.GetAllAsync();
                _response.Result = _mapper.Map<List<EmployeeDTO>>(employeeList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpGet("{id:int}", Name ="GetEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> GetEmployee(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadGateway;
                    return BadRequest(_response);
                }
                var employee = await _dbEmployee.GetAsync(u => u.Id == id);
                if (employee == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<EmployeeDTO>(employee);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex) 
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message
    };
}
return _response;
        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ApiResponse>> CreateEmployee([FromBody] EmployeeCreateDTO createDTO) 
        {
            try
            {
                if (await _dbEmployee.GetAsync(u => u.Name.ToLower() == createDTO.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Employee already exists!");
                    return BadRequest(ModelState);
                }
                if (await _dbDepartment.GetAsync(u => u.Id == createDTO.DepartmentId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "DepartmentID is invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbDesignation.GetAsync(u => u.Id == createDTO.DesignationId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "DesignationID is invalid");
                    return BadRequest(ModelState);
                }
                if (createDTO == null)
                {
                    return BadRequest();
                }
                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }
                Employee employee = _mapper.Map<Employee>(createDTO);

                await _dbEmployee.CreateAsync(employee);
                _response.Result = _mapper.Map<List<EmployeeDTO>>(employee);
                _response.StatusCode = HttpStatusCode.OK;
                return CreatedAtRoute("GetEmployee", new { id = employee.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse>> DeleteEmploy(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var employee = await _dbEmployee.GetAsync(u => u.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                await _dbEmployee.RemoveAsync(employee);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;
        }

        [HttpPut("id:int", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse>> UpdateEmployee(int id, [FromBody]EmployeeUpdateDTO updateDTO)
        {
            try { 
            if(updateDTO == null || id != updateDTO.Id)
            {
                return BadRequest();
            }
                if (await _dbDepartment.GetAsync(u => u.Id == updateDTO.DepartmentId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "DeprtmentID is invalid");
                    return BadRequest(ModelState);
                }
                if (await _dbDesignation.GetAsync(u => u.Id == updateDTO.DesignationId) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "DesignationId is invalid");
                    return BadRequest(ModelState);
                }

                Employee model = _mapper.Map<Employee>(updateDTO);
           await _dbEmployee.UpdateAsync(model);

            _response.StatusCode = HttpStatusCode.NoContent;
            _response.IsSuccess=true;
            return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.Message };
            }
            return _response;

        }



    }
}
