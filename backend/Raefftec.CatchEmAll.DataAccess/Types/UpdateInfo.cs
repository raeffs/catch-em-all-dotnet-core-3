using System;
using Microsoft.EntityFrameworkCore;

namespace Raefftec.CatchEmAll.Types
{
    [Owned]
    public class UpdateInfo
    {
        public DateTimeOffset Updated { get; private set; }

        public bool IsLocked { get; private set; }

        public int NumberOfFailures { get; private set; }

        public UpdateInfo()
        {
            this.Updated = DateTimeOffset.Now;
        }

        public UpdateInfo Lock()
        {
            if (this.IsLocked)
            {
                // todo proper exception
                throw new Exception();
            }

            return new UpdateInfo
            {
                Updated = this.Updated,
                IsLocked = true
            };
        }

        public UpdateInfo MarkAsSuccessful()
        {
            if (!this.IsLocked)
            {
                // todo proper exception
                throw new Exception();
            }

            return new UpdateInfo
            {
                Updated = DateTimeOffset.Now,
                IsLocked = false,
                NumberOfFailures = 0
            };
        }

        public UpdateInfo MarkAsFailed()
        {
            if (!this.IsLocked)
            {
                // todo proper exception
                throw new Exception();
            }

            return new UpdateInfo
            {
                Updated = this.Updated,
                IsLocked = false,
                NumberOfFailures = this.NumberOfFailures + 1
            };
        }
    }
}
