using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NagarPalika.Application.Commands.AccessPermissions;
using NagarPalika.Application.Commands.Departments;
using NagarPalika.Application.Commands.Designations;
using NagarPalika.Application.Commands.Districts;
using NagarPalika.Application.Commands.Employees;
using NagarPalika.Application.Commands.Localitys;
using NagarPalika.Application.Commands.Organization;
using NagarPalika.Application.Commands.Role;
using NagarPalika.Application.Commands.User;
using NagarPalika.Application.Commands.Ward;
using NagarPalika.Application.Commands.Zone;
using NagarPalika.Application.Queries.AccessPermissions;
using NagarPalika.Application.Queries.Departments;
using NagarPalika.Application.Queries.Designations;
using NagarPalika.Application.Queries.Districts;
using NagarPalika.Application.Queries.Employees;
using NagarPalika.Application.Queries.Localitys;
using NagarPalika.Application.Queries.Modules;
using NagarPalika.Application.Queries.Organization;
using NagarPalika.Application.Queries.Role;
using NagarPalika.Application.Queries.Ward;
using NagarPalika.Application.Queries.Zone;
using NagarPalika.Application.UnitOfWork;
using NagarPalika.Domain.Entity;
using NagarPalika.Domain.ViewModels;

namespace NagarPalika.Web.Controllers
{
    [CustomAuthorizationAttribute]
    public class MastersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IUnitofWork _unitofwork;

        public MastersController(IMediator mediator, ILogger<HomeController> logger, IUnitofWork unitofwork)
        {
            _mediator = mediator;
            _logger = logger;
            _unitofwork = unitofwork;
        }

        #region comment
        //[AllowAnonymous]
        //public async Task<IActionResult> ModuleList(GetModulesByFilterQuery request)
        //{
        //    _logger.LogInformation(nameof(EmployeeList), request);
        //    var emploist = await _mediator.Send(request);
        //    return Ok(emploist);
        //}
        #endregion

        #region Employee Section

        public async Task<IActionResult> EmployeeList()
        {
            _logger.LogInformation(nameof(EmployeeList));
            return View();
        }
        public async Task<IActionResult> BindEmployeeList(DTParameters para, GetAllEmployeeQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "EmployeeName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(EmployeeList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditEmployee(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditEmployee));
            var request = new CreateEmployeeCommand();
            var departmentList = await _unitofwork.Departments.GetALL();
            ViewBag.DeptList = departmentList.Where(w => w.IsActive == true).ToList();
            var designationList = await _unitofwork.Designations.GetALL();
            ViewBag.DesignationList = designationList.Where(w => w.IsActive == true).ToList();
            var UsertypeList = await _unitofwork.UserType.GetALL();
            ViewBag.UserTypeList = UsertypeList.Where(w => w.IsActive == true).ToList();
            var RoleList = await _unitofwork.Roles.GetALL();
            ViewBag.RoleList = RoleList.Where(w => w.IsActive == true).ToList();
            var EmpList = await _unitofwork.Employee.GetALL();
            ViewBag.EmpList = EmpList.Where(w => w.IsActive == true).ToList();
            var OrgList = await _unitofwork.Organizations.GetALL();
            ViewBag.OrgList = OrgList.Where(w => w.IsActive == true).ToList();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetEmployeeByIdQuery { UserId = Id });
                request = empl.Data.Adapt<CreateEmployeeCommand>();
            }
            return View(request);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditEmployee(CreateEmployeeCommand command)
        {
            _logger.LogInformation(nameof(AddEditEmployee), command);
            if (command.EmployeeId > 0)
            {
                var req = command.Adapt<UpdateEmployeeCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }
        }
        public async Task<IActionResult> DeleteEmployee(int EmployeeId)
        {
            _logger.LogInformation(nameof(DeleteEmployee), EmployeeId);
            var empl = await _mediator.Send(new DeleteEmployeeCommand { EmployeeId = EmployeeId });
            return Ok(empl);
        }
        #endregion

        #region Department Section


        public async Task<IActionResult> DepartmentList()
        {
            _logger.LogInformation(nameof(DepartmentList));
            return View();
        }
        public async Task<IActionResult> BindDepartmentList(DTParameters para, GetDepartmentByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "DepartmentName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(BindDepartmentList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditDepartment(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditDepartment), Id);
            var req = new CreateDepartmentCommand();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetDepartmentByIdQuery { DepartmentId = Id });
                req = empl.Data.Adapt<CreateDepartmentCommand>();
            }
            return PartialView("/views/masters/_addeditDepartment.cshtml", req);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditDepartment(CreateDepartmentCommand command)
        {
            _logger.LogInformation(nameof(AddEditDepartment), command);
            if (command.DepartmentId > 0)
            {
                var req = command.Adapt<UpdateDepartmentCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteDepartment(int DepartmentId)
        {
            _logger.LogInformation(nameof(DeleteDepartment), DepartmentId);
            var empl = await _mediator.Send(new DeleteDepartmentCommand { DepartmentId = DepartmentId });
            return Json(empl);
        }

        #endregion

        #region Organisation Section
        [HttpPost]
        public async Task<IActionResult> BindOrganizationList(DTParameters para, GetOrganizationByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "orgName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(BindOrganizationList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });

        }
        public async Task<IActionResult> OrganizationList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddOrganization()
        {
            _logger.LogInformation(nameof(AddOrganization));
            var district = await _unitofwork.Districts.GetALL();
            var districtList = district.Where(w => w.IsActive == true).ToList().Adapt<List<DistrictVM>>();
            var ULBTypeList = new List<SelectItem>();
            ULBTypeList.Add(new SelectItem { Value = "Nagar Nigam", Text = "Nagar Nigam" });
            ULBTypeList.Add(new SelectItem { Value = "Nagar Palika Parishad", Text = "Nagar Palika Parishad" });
            ULBTypeList.Add(new SelectItem { Value = "Nagar Panchayat", Text = "Nagar Panchayat" });
            ViewBag.ULBTypeList = ULBTypeList;
            ViewBag.DistrictList = districtList;
            var request = new CreateOrganizationCommand();
            return View(request);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrganization([FromForm] CreateOrganizationCommand command)
        {
            _logger.LogInformation(nameof(AddOrganization), command);
            var empl = await _mediator.Send(command);
            return Json(empl);
        }
        public async Task<IActionResult> EditOrganization(int OrganizationId)
        {
            _logger.LogInformation(nameof(EditOrganization), OrganizationId);
            var empl = await _mediator.Send(new GetOrganizationByIdQuery { OrganizationId = OrganizationId });
            return View(empl);
        }
        public async Task<IActionResult> EditOrganization(UpdateOrganizationCommand command)
        {
            _logger.LogInformation(nameof(EditOrganization), command);
            var empl = await _mediator.Send(command);
            return Ok(empl);
        }

        #endregion

        #region Designation Section

        public async Task<IActionResult> DesignationList()
        {
            _logger.LogInformation(nameof(DesignationList));
            return View();
        }
        public async Task<IActionResult> BindDesignationList(DTParameters para, GetDesignationByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "DesignationName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(BindDesignationList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditDesignation(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditDesignation), Id);
            var req = new CreateDesignationCommand();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetDesignationByIdQuery { DesignationId = Id });
                req = empl.Data.Adapt<CreateDesignationCommand>();
            }
            return PartialView("/views/masters/_addeditdesignation.cshtml", req);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditDesignation(CreateDesignationCommand command)
        {
            _logger.LogInformation(nameof(AddEditDesignation), command);
            if (command.DesignationId > 0)
            {
                var req = command.Adapt<UpdateDesignationCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteDesignation(int DesignationId)
        {
            _logger.LogInformation(nameof(DeleteDesignation), DesignationId);
            var empl = await _mediator.Send(new DeleteDesignationCommand { DesignationId = DesignationId });
            return Json(empl);
        }


        #endregion

        #region Wards Section
        public async Task<IActionResult> WardsList()
        {
            _logger.LogInformation(nameof(WardsList));
            return View();
        }
        public async Task<IActionResult> BindWardsList(DTParameters para, GetWardsByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "WardName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(BindWardsList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditWards(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditWards), Id);
            var zones = await _unitofwork.Zones.GetALL();
            var zoneList = zones.Where(w => w.IsActive == true).ToList().Adapt<List<ZonesVM>>();
            ViewBag.ZoneList = zoneList;
            var req = new CreateWardsCommand();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetWardsByIdQuery { WardId = Id });
                req = empl.Data.Adapt<CreateWardsCommand>();
            }
            return PartialView("/views/masters/_addeditWards.cshtml", req);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditWards(CreateWardsCommand command)
        {
            _logger.LogInformation(nameof(AddEditWards), command);
            if (command.WardId > 0)
            {
                var req = command.Adapt<UpdateWardsCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteWards(int WardsId)
        {
            _logger.LogInformation(nameof(DeleteWards), WardsId);
            var empl = await _mediator.Send(new DeleteWardsCommand { WardId = WardsId });
            return Json(empl);
        }

        #endregion

        #region Zones Section
        public async Task<IActionResult> ZonesList()
        {
            _logger.LogInformation(nameof(ZonesList));
            return View();
        }
        public async Task<IActionResult> BindZonesList(DTParameters para, GetZonesByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "ZoneName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(BindZonesList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditZones(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditZones), Id);
            var district = await _unitofwork.Districts.GetALL();
            var districtList = district.Where(w => w.IsActive == true).ToList().Adapt<List<DistrictVM>>();
            ViewBag.DistrictList = districtList;
            var req = new CreateZonesCommand();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetZonesByIdQuery { ZoneId = Id });
                req = empl.Data.Adapt<CreateZonesCommand>();
            }
            return PartialView("/views/masters/_addeditZones.cshtml", req);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditZones(CreateZonesCommand command)
        {
            _logger.LogInformation(nameof(AddEditZones), command);
            if (command.ZoneId > 0)
            {
                var req = command.Adapt<UpdateZonesCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteZones(int ZonesId)
        {
            _logger.LogInformation(nameof(DeleteZones), ZonesId);
            var empl = await _mediator.Send(new DeleteZonesCommand { ZoneId = ZonesId });
            return Json(empl);
        }

        #endregion

        #region District Section
        public async Task<IActionResult> DistrictList()
        {
            _logger.LogInformation(nameof(DistrictList));
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BindDistrictList(DTParameters para, GetDistrictByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "DistrictName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(BindDistrictList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditDistrict(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditDistrict), Id);
            var req = new CreateDistrictCommand();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetDistrictByIdQuery { DistrictId = Id });
                req = empl.Data.Adapt<CreateDistrictCommand>();
            }
            return PartialView("/views/masters/_addeditDistrict.cshtml", req);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditDistrict(CreateDistrictCommand command)
        {
            _logger.LogInformation(nameof(AddEditDistrict), command);
            if (command.DistrictId > 0)
            {
                var req = command.Adapt<UpdateDistrictCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteDistrict(int DistrictId)
        {
            _logger.LogInformation(nameof(DeleteDistrict), DistrictId);
            var empl = await _mediator.Send(new DeleteDistrictCommand { DistrictId = DistrictId });
            return Json(empl);
        }

        #endregion

        #region Roles Section
        public async Task<IActionResult> RoleList()
        {
            _logger.LogInformation(nameof(RoleList));
            return View();
        }
        public async Task<IActionResult> BindRoleList(DTParameters para, GetRolesByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "RoleName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(BindRoleList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditRole(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditRole), Id);
            var req = new CreateRolesCommand();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetRolesByIdQuery { RoleId = Id });
                req = empl.Data.Adapt<CreateRolesCommand>();
            }
            return PartialView("/views/masters/_addeditRole.cshtml", req);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditRole(CreateRolesCommand command)
        {
            _logger.LogInformation(nameof(AddEditRole), command);
            if (command.RoleId > 0)
            {
                var req = command.Adapt<UpdateRolesCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(int RoleId)
        {
            _logger.LogInformation(nameof(DeleteRole), RoleId);
            var empl = await _mediator.Send(new DeleteRolesCommand { RoleId = RoleId });
            return Json(empl);
        }

        #endregion

        #region Locality Section
        public async Task<IActionResult> LocalityList()
        {
            _logger.LogInformation(nameof(LocalityList));
            return View();
        }
        public async Task<IActionResult> BindLocalityList(DTParameters para, GetLocalityByFilterQuery request)
        {
            if (para.Order != null)
            {
                request.SortOrder = Convert.ToString(para.Order[0].Dir).ToLower();
            }
            if (para.SortOrder != null)
            {
                if (para.SortOrder.Contains("."))
                {
                    request.SortBy = para.SortOrder.Split('.')[1];
                }
                else
                {
                    request.SortBy = para.SortOrder;
                }

            }
            else
            {
                request.SortBy = "LocalityName";
                request.SortOrder = "asc";
            }
            request.PageSize = para.Length;
            request.SkipRow = para.Start;
            _logger.LogInformation(nameof(BindLocalityList), request);
            var emploist = await _mediator.Send(request);
            return Json(new { draw = para.Draw, recordsFiltered = emploist.TotalRecord, recordsTotal = emploist.TotalRecord, data = emploist.Data });
        }
        public async Task<IActionResult> AddEditLocality(int Id = 0)
        {
            _logger.LogInformation(nameof(AddEditLocality), Id);
            var wards = await _unitofwork.Wards.GetALL();
            var wardList = wards.Where(w => w.IsActive == true).ToList().Adapt<List<WardsVM>>();
            ViewBag.WardList = wardList;
            var req = new CreateLocalityCommand();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetLocalityByIdQuery { LocalityId = Id });
                req = empl.Data.Adapt<CreateLocalityCommand>();
            }
            return PartialView("/views/masters/_addeditLocality.cshtml", req);
        }
        [HttpPost]
        public async Task<IActionResult> AddEditLocality(CreateLocalityCommand command)
        {
            _logger.LogInformation(nameof(AddEditLocality), command);
            if (command.LocalityId > 0)
            {
                var req = command.Adapt<UpdateLocalityCommand>();
                var empl = await _mediator.Send(req);
                return Json(empl);
            }
            else
            {
                var empl = await _mediator.Send(command);
                return Json(empl);
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteLocality(int LocalityId)
        {
            _logger.LogInformation(nameof(DeleteLocality), LocalityId);
            var empl = await _mediator.Send(new DeleteLocalityCommand { LocalityId = LocalityId });
            return Json(empl);
        }

        #endregion


        #region User Permission
        public async Task<IActionResult> PermissionList()
        {
            _logger.LogInformation(nameof(PermissionList));
            var roleList = await _unitofwork.Roles.GetALL();
            ViewBag.RoleList = roleList.ToList();
            return View("/views/masters/ModuleList.cshtml");
        }
        public async Task<IActionResult> BindPermissionList(GetAccessPermissionByFilterQuery request)
        {

            _logger.LogInformation(nameof(BindPermissionList), request);
            var empPermission = await _mediator.Send(request);
            var moduleList = await _mediator.Send(new GetModulesByFilterQuery { IsPermission = true });
            //var roleList = await _unitofwork.Roles.GetALL();
            //ViewBag.RoleList = roleList.ToList();

            var commandList = new List<AccessPermissionData>();
            foreach (var module in moduleList)
            {
                var command = new AccessPermissionData();
                command.ModuleId = module.ModuleId;
                command.ModuleName = module.ModuleName;
                command.ParentId = module.ParentId;
                if (empPermission.Count() > 0)
                {
                    var perm = empPermission.Where(w => w.ModuleId == module.ModuleId).FirstOrDefault();
                    if(perm!=null)
                    {
                        command.CanAdd = perm.CanAdd;
                        command.CanEdit = perm.CanEdit;
                        command.CanView = perm.CanView;
                        command.CanDelete = perm.CanDelete;
                    }
                    else
                    {
                        command.CanAdd = false;
                        command.CanEdit = false;
                        command.CanView = false;
                        command.CanDelete = false;
                    }
                  
                    //command.RoleId = perm.RoleId;
                }
                else
                {
                    command.CanAdd = false;
                    command.CanEdit = false;
                    command.CanView = false;
                    command.CanDelete = false;
                }
                commandList.Add(command);
            }
            var permissionList = new CreateAccessPermissionCommand();
            permissionList.RoleId = request.RoleId;
            permissionList.PermissionDatas = commandList;

            return PartialView("/views/masters/_UserPermission.cshtml", permissionList);
        }
        public async Task<IActionResult> AssignPermission(int Id = 0)
        {
            _logger.LogInformation(nameof(AssignPermission), Id);
            var req = new CreateRolesCommand();
            if (Id > 0)
            {
                var empl = await _mediator.Send(new GetRolesByIdQuery { RoleId = Id });
                req = empl.Data.Adapt<CreateRolesCommand>();
            }
            return PartialView("/views/masters/_addeditRole.cshtml", req);
        }
        [HttpPost]
        public async Task<IActionResult> AssignPermission(CreateAccessPermissionCommand command)
        {
            _logger.LogInformation(nameof(AssignPermission), command);
            var empl = await _mediator.Send(command);
            return Json(empl);

        }



        #endregion
    }
}
