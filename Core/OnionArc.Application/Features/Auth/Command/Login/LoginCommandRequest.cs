using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArc.Application.Features.Auth.Command.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    [DefaultValue("gs@gmail.com")]
    public string Email { get; set; }
    [DefaultValue("123456")]
    public string Password { get; set; }
}
