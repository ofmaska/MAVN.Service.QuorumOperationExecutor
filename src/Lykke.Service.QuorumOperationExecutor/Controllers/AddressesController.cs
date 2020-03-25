﻿using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Lykke.Service.QuorumOperationExecutor.Client;
using Lykke.Service.QuorumOperationExecutor.Client.Models.Responses;
using Lykke.Service.QuorumOperationExecutor.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.QuorumOperationExecutor.Controllers
{
    [ApiController]
    [Route("api/addresses")]
    public class AddressesController : ControllerBase, IQuorumOperationExecutorAddressesApi
    {
        private readonly ITokenService _tokenService;

        public AddressesController(
            ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        
        /// <summary>
        /// Returns the balance of a specific address
        /// </summary>
        /// <param name="address"></param>
        [HttpGet("{address}/balance")]
        public async Task<AddressBalanceResponse> GetBalanceForAddressAsync(
            [Required] string address)
        {
            return new AddressBalanceResponse
            {
                Balance = await _tokenService.GetBalanceAsync(address),
                StakedBalance = await _tokenService.GetStakedBalanceAsync(address)
            };
        }
    }
}
