using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using SmartPartsFrame.Model.DatabaseTools.SQL;

namespace SmartPartsFrame.Patterns.Command
{
    public abstract class TagCommandComponentBase
    {
        protected TagCommandReceiver receiver;
        public int TagId { get; private set; }

        public TagCommandComponentBase(TagCommandReceiver receiver, int tagId)
        {
            this.receiver = receiver;
            this.TagId = tagId;
        }

        public abstract void Add(TagCommandComponentBase c);
        public abstract void Remove(TagCommandComponentBase c);
        public abstract void Execute();
    }

    public class TagCommand : TagCommandComponentBase
    {
        protected ArrayList childrenCommands = new ArrayList();

        public TagCommand(TagCommandReceiver receiver, int tagId) : base(receiver, tagId) { ;}

        public override void Add(TagCommandComponentBase c)
        {
            childrenCommands.Add(c);
        }

        public override void Remove(TagCommandComponentBase c)
        {
            childrenCommands.Remove(c);
        }

        public override void Execute()
        {
            foreach (TagCommandComponentBase c in childrenCommands)
            {
                c.Execute();
            }
        }
    }

    public class StatusCommand : TagCommand
    {
        public StatusCommand(TagCommandReceiver receiver, int tagId) : base(receiver, tagId) { ;}
        public Status TagStatus { get; set; }

        public override void Execute()
        {
            receiver.SetStatus(TagId, TagStatus);
            base.Execute();
        }
    }

    public class AssignationCommand : TagCommand
    {
        public AssignationCommand(TagCommandReceiver receiver, int tagId) : base(receiver, tagId) { ;}

        public int AssignationId { get; set; }

        public Assignation AssigrationType { get; set; }

        public override void Execute()
        {
            receiver.Assignation(TagId, AssignationId, AssigrationType);
            base.Execute();
        }
    }

    public class PlanningCommand : TagCommand
    {
        public PlanningCommand(TagCommandReceiver receiver, int tagId) : base(receiver, tagId) { ;}

        public DateTime PlanningDate { get; set; }

        public override void Execute()
        {
            receiver.Plan(TagId, PlanningDate);
            base.Execute();
        }
    }

    public class EfficacyCommand : TagCommand
    {
        public EfficacyCommand(TagCommandReceiver receiver, int tagId) : base(receiver, tagId) { ;}

        public int Efficacy { get; set; }

        public override void Execute()
        {
            receiver.Efficacy(TagId, Efficacy);
            base.Execute();
        }
    }

    public class EffortCommand : TagCommand
    {
        public EffortCommand(TagCommandReceiver receiver, int tagId) : base(receiver, tagId) { ;}

        public int Effort { get; set; }

        public override void Execute()
        {
            receiver.Effort(TagId, Effort);
            base.Execute();
        }
    }

    public class PriorityCommand : TagCommand
    {
        public PriorityCommand(TagCommandReceiver receiver, int tagId) : base(receiver, tagId) { ;}

        public int Priority { get; set; }

        public override void Execute()
        {
            receiver.Priority(TagId, Priority);
            base.Execute();
        }
    }

    public class CommentCommand : TagCommand
    {
        public CommentCommand(TagCommandReceiver receiver, int tagId) : base(receiver, tagId) { ;}

        public string Comment { get; set; }

        public override void Execute()
        {
            receiver.Comment(TagId, Comment);
            base.Execute();
        }
    }

    public class TagCommandReceiver
    {
        volatile static TagCommandReceiver instance = null;
        static Object syncObj = new Object();
        SqlModel sql = new SqlModel();

        private TagCommandReceiver()
        {
            sql = new SqlModel("tr.TagCommandReceiver");

            sql.Add("@TagStatus", System.Data.SqlDbType.Int);
            sql.Add("@PlanningDate", System.Data.SqlDbType.DateTime);
            sql.Add("@Comment", System.Data.SqlDbType.NVarChar);
            sql.Add("@Effort", System.Data.SqlDbType.Int);
            sql.Add("@Efficacy", System.Data.SqlDbType.Int);
            sql.Add("@Priority", System.Data.SqlDbType.Int);
            sql.Add("@AssignationId", System.Data.SqlDbType.Int);
            sql.Add("@AssigrationType", System.Data.SqlDbType.Int);
        }

        public static TagCommandReceiver Instance
        {
            get
            {
                lock (syncObj)
                {
                    if (instance == null)
                        instance = new TagCommandReceiver();

                    return instance;
                }
            }
        }

        internal void SetStatus(int TagId, Status TagStatus)
        {
            sql.SetParameterValue("@TagStatus", TagStatus);
         }

        internal void Plan(int TagId, DateTime PlanningDate)
        {
            sql.SetParameterValue("@PlanningDate", PlanningDate);
        }

        internal void Comment(int TagId, string Comment)
        {
            sql.SetParameterValue("@Comment", Comment);
        }

        internal void Effort(int TagId, int Effort)
        {
            sql.SetParameterValue("@Effort", Effort);
        }

        internal void Efficacy(int TagId, int Efficacy)
        {
            sql.SetParameterValue("@Efficacy", Efficacy);
        }

        internal void Priority(int TagId, int Priority)
        {
            sql.SetParameterValue("@Priority", Priority);
        }

        internal void Assignation(int TagId, int AssignationId, Assignation AssigrationType)
        {
            sql.SetParameterValue("@AssignationId", AssignationId);
            sql.SetParameterValue("@AssigrationType", AssigrationType);
        }

        public void ExecuteSqlCommand()
        {
            sql.ExecuteNonQuery();
        }

    }

    public enum Assignation { SUPERINTENDENT, TECHNICALDEPARTMENT}
    
    public enum Status { INTRODUCED, ASSIGNED, REFUSED, PLANNED, COMPLETED, CLOSED}
}