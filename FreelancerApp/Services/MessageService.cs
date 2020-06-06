using Data;
using Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MessageService
    {
        private readonly Guid _userId;

        public MessageService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateMessage(MessageCreate model)
        {
            var entity = new Message()
            {
                Content = model.Content,
                EmployerId = model.EmployerId,
                FreelancerId = model.FreelancerId,
                CreatedUTC = DateTimeOffset.UtcNow
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Messages.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MessageList> GetMessages()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Messages
                    .Where(e => e.Employer.UserId == _userId.ToString() || e.Freelancer.UserId == _userId.ToString())
                    .Select(e => new MessageList
                    {
                        MessageId = e.MessageId,
                        EmployerId = e.EmployerId,
                        FreelancerId = e.FreelancerId,
                        IsRead = e.IsRead
                    });
                return query.ToArray();
            }
        }

        public MessageDetail GetMessageById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Messages
                    .Single(e => e.MessageId == id && e.Employer.UserId == _userId.ToString() || e.Freelancer.UserId == _userId.ToString());
                return
                    new MessageDetail
                    {
                        Content = entity.Content,
                        EmployerId = entity.EmployerId,
                        FreelancerId = entity.FreelancerId,
                        IsRead = entity.IsRead,
                        CreatedUTC = entity.CreatedUTC
                    };
            }
        }

        public bool UpdateMessage(MessageUpdate messageToUpdate)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Messages
                    .Single(e => e.MessageId == messageToUpdate.MessageId && e.Employer.UserId == _userId.ToString() || e.Freelancer.UserId == _userId.ToString());

                entity.MessageId = messageToUpdate.MessageId;
                entity.Content = messageToUpdate.Content;
                entity.IsRead = messageToUpdate.IsRead;
                entity.ModifiedUTC = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMessage(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Messages
                        .Single(e => e.MessageId == id && e.Employer.UserId == _userId.ToString() || e.Freelancer.UserId == _userId.ToString());

                ctx.Messages.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
