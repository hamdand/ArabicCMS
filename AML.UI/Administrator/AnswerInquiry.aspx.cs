using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AML.UI.Administrator
{
    public partial class AnswerInquiry : BaseAdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var item = InquiryService.GetById(selectedId);
                txtTitle.Text = item.Name;
                txtDesc.Text = item.Description;

                txtEntityName.Text = EntityService.GetById(int.Parse(GetUserInformation(item.UserId).EntityName), Domain.Helper.Lang.Arabic.ToString()).Name;
                txtSubmitterName.Text = GetUserInformation(item.UserId).FirstName + " " + GetUserInformation(item.UserId).LastName;

                if(item.Answers != null && item.Answers.Count>0)
                {
                    txtAnswer.Text = item.Answers[0].Answer;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var item = InquiryService.GetById(selectedId);
                item.IsPublic = checkItems.Items[0].Selected;
                item.IsClosed = true;
                item.Answers.Add(new Domain.Application.InquiryAnswer()
                {
                    Answer = txtAnswer.Text,
                    Created = DateTime.Now,
                    IsArabic = item.IsArabic,
                    SortId = 0,
                    UserId = currentUserId,
                    IsPublic=checkItems.Items[0].Selected
                });

                InquiryService.Update(item);
            }
        }
    }
}