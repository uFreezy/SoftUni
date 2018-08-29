namespace BangaloreUniversityLearningSystem
{
    using System.Text;
    using Core.Interfaces;

    public abstract class View : IView
    {
        protected View(object model)
        {
            this.Model = model;
        }

        public object Model { get; private set; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            this.BuildViewResult(viewResult);

            return viewResult.ToString().Trim();
        }

        ////BUG: possible bug => virtual to abstract
        internal abstract void BuildViewResult(StringBuilder viewResult);
    }
}