using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OnionArc.Application.Bases;
using OnionArc.Application.Features.Auth.Rules;
using OnionArc.Application.Interfaces.AutoMapper;
using OnionArc.Application.Interfaces.UnitOfWorks;
using OnionArc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Features.Auth.Command.Revoke;

class RevokeCommandHAndler : BaseHandler, IRequestHandler<RevokeCommandRequest, Unit>
{
    private readonly UserManager<User> userManager;
    private readonly AuthRules authRules;

    public RevokeCommandHAndler(UserManager<User> userManager, AuthRules authRules, IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
    {
        this.userManager = userManager;
        this.authRules = authRules;
    }

    public async Task<Unit> Handle(RevokeCommandRequest request, CancellationToken cancellationToken)
    {
        User? user = await userManager.FindByEmailAsync(request.Email);
        await authRules.EmailAddressShouldBeValid(user);

        user.RefreshToken = null;
        await userManager.UpdateAsync(user);

        return Unit.Value;
    }
}
