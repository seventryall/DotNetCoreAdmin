using AutoMapper;
using Jun.Admin.EntityFramework.Contract;
using Jun.Admin.Service.Contract;
using Jun.Admin.Service.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Jun.Admin.Service
{
    public class FunctionService : BaseService, IFunctionService
    {
        private readonly IFunctionRepository _funcRepository;
        private readonly IMapper _mapper;

        public FunctionService(IFunctionRepository funcRepository,
            IMapper mapper)
        {
            _funcRepository = funcRepository;
            _mapper = mapper;
        }

         public ResponseData<List<FunctionDto>> GetFunctionList()
        {
            var res = DoInvoke<List<FunctionDto>>(resp =>
            {
                var entities = _funcRepository.GetAllFunction();
                var dtoList = _mapper.Map<List<FunctionDto>>(entities);
                resp.data = dtoList;

            });
            return res;
        }
    }
}
