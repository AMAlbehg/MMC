using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMC.Application.Modules.Speakers.Commands.Create
{
    public class CreateSpeakerValidator : AbstractValidator<CreateSpeakerCommand>
    {
        public CreateSpeakerValidator()
        {
            RuleFor(p=>p.AdresseMail).NotEmpty().WithMessage("The name should not be empty") ;
        }

    }
}
