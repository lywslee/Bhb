using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Common;

namespace Web.admin.page
{
    public partial class ArticleEdit : Web.UI.ManagePage
    {
        private string action = MXEnums.ActionEnum.Add.ToString(); //操作类型

        private int id = 0;
        string category_id = "";
        string levelName = "";
        //页面初始化事件
        protected void Page_Init(object sernder, EventArgs e)
        {
        }

        //页面加载事件
        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = MXRequest.GetQueryString("action");
            category_id = MXRequest.GetQueryString("category_id");
            levelName = MXRequest.GetQueryString("levelName");
            if (!string.IsNullOrEmpty(_action) && _action == MXEnums.ActionEnum.Edit.ToString())
            {
                this.action = MXEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = MXRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.article().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel(levelName, MXEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(); //绑定类别
                if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind()
        {

            BLL.article_category bll = new BLL.article_category();
            DataTable dt = bll.GetWCodeList(" and class_list like '%," + category_id + ",%'");
            this.ddlCategoryId.Items.Clear();
            this.ddlCategoryId.Items.Add(new ListItem("请选择类别...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                string Id = dr["id"].ToString();
                int ClassLayer = int.Parse(dr["class_layer"].ToString());
                string Title = dr["title"].ToString().Trim();

                if (ClassLayer == 1)
                {
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
                else
                {
                    Title = "├ " + Title;
                    Title = Utils.StringOfChar(ClassLayer - 1, "　") + Title;
                    this.ddlCategoryId.Items.Add(new ListItem(Title, Id));
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.article bll = new BLL.article();
            Model.article model = bll.GetModel(_id);

            ddlCategoryId.SelectedValue = model.category_id.ToString();
            txtCallIndex.Text = model.call_index;
            txtTitle.Text = model.title;
            txtLinkUrl.Text = model.link_url;
            //不是相册图片就绑定
            string filename = model.img_url.Substring(model.img_url.LastIndexOf("/") + 1);
            if (!filename.StartsWith("thumb_"))
            {
                txtImgUrl.Text = model.img_url;
            }
            txtSeoTitle.Text = model.seo_title;
            txtSeoKeywords.Text = model.seo_keywords;
            txtSeoDescription.Text = model.seo_description;
            txtZhaiyao.Text = model.zhaiyao;
            txtContent.Value = model.content;
            txtSortId.Text = model.sort_id.ToString();
            txtClick.Text = model.click.ToString();
            rblStatus.SelectedValue = model.status.ToString();
            txtAddTime.Text = model.add_time.ToString("yyyy-MM-dd HH:mm:ss");
            if (model.is_msg == 1)
            {
                cblItem.Items[0].Selected = true;
            }
            if (model.is_top == 1)
            {
                cblItem.Items[1].Selected = true;
            }
            if (model.is_red == 1)
            {
                cblItem.Items[2].Selected = true;
            }
            if (model.is_hot == 1)
            {
                cblItem.Items[3].Selected = true;
            }
            if (model.is_slide == 1)
            {
                cblItem.Items[4].Selected = true;
            }
            //绑定图片相册
            if (filename.StartsWith("thumb_"))
            {
                hidFocusPhoto.Value = model.img_url; //封面图片
            }
            rptAlbumList.DataSource = model.albums;
            rptAlbumList.DataBind();
            //绑定内容附件
            rptAttachList.DataSource = model.attach;
            rptAttachList.DataBind();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.article model = new Model.article();
            BLL.article bll = new BLL.article();

            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.seo_title = txtSeoTitle.Text.Trim();
            model.seo_keywords = txtSeoKeywords.Text.Trim();
            model.seo_description = txtSeoDescription.Text.Trim();
            //内容摘要提取内容前255个字符
            if (string.IsNullOrEmpty(txtZhaiyao.Text.Trim()))
            {
                model.zhaiyao = Utils.DropHTML(txtContent.Value, 255);
            }
            else
            {
                model.zhaiyao = Utils.DropHTML(txtZhaiyao.Text, 255);
            }
            model.content = txtContent.Value;
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.click = int.Parse(txtClick.Text.Trim());
            model.status = Utils.StrToInt(rblStatus.SelectedValue, 0);
            model.is_msg = 0;
            model.is_top = 0;
            model.is_red = 0;
            model.is_hot = 0;
            model.is_slide = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.is_msg = 1;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.is_top = 1;
            }
            if (cblItem.Items[2].Selected == true)
            {
                model.is_red = 1;
            }
            if (cblItem.Items[3].Selected == true)
            {
                model.is_hot = 1;
            }
            if (cblItem.Items[4].Selected == true)
            {
                model.is_slide = 1;
            }
            model.is_sys = 1; //管理员发布
            model.user_name = "admin"; //获得当前登录用户名
            model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());

            #region 保存相册====================
            //检查是否有自定义图片
            if (txtImgUrl.Text.Trim() == "")
            {
                model.img_url = hidFocusPhoto.Value;
            }
            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            if (albumArr != null && albumArr.Length > 0)
            {
                List<Model.article_albums> ls = new List<Model.article_albums>();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    if (imgArr.Length == 3)
                    {
                        if (!string.IsNullOrEmpty(remarkArr[i]))
                        {
                            ls.Add(new Model.article_albums { original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                        }
                        else
                        {
                            ls.Add(new Model.article_albums { original_path = imgArr[1], thumb_path = imgArr[2] });
                        }
                    }
                }
                model.albums = ls;
            }
            #endregion

            #region 保存附件====================
            //保存附件
            string[] attachFileNameArr = Request.Form.GetValues("hid_attach_filename");
            string[] attachFilePathArr = Request.Form.GetValues("hid_attach_filepath");
            string[] attachFileSizeArr = Request.Form.GetValues("hid_attach_filesize");
            string[] attachPointArr = Request.Form.GetValues("txt_attach_point");
            if (attachFileNameArr != null && attachFilePathArr != null && attachFileSizeArr != null && attachPointArr != null
                && attachFileNameArr.Length > 0 && attachFilePathArr.Length > 0 && attachFileSizeArr.Length > 0 && attachPointArr.Length > 0)
            {
                List<Model.article_attach> ls = new List<Model.article_attach>();
                for (int i = 0; i < attachFileNameArr.Length; i++)
                {
                    int fileSize = Utils.StrToInt(attachFileSizeArr[i], 0);
                    string fileExt = Utils.GetFileExt(attachFilePathArr[i]);
                    int _point = Utils.StrToInt(attachPointArr[i], 0);
                    ls.Add(new Model.article_attach { file_name = attachFileNameArr[i], file_path = attachFilePathArr[i], file_size = fileSize, file_ext = fileExt, point = _point });
                }
                model.attach = ls;
            }
            #endregion

            if (bll.Add(model) > 0)
            {
                //开始生成缩略图咯

                AddAdminLog(MXEnums.ActionEnum.Add.ToString(), "添加" + levelName + "内容:" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.article bll = new BLL.article();
            Model.article model = bll.GetModel(_id);

            model.category_id = Utils.StrToInt(ddlCategoryId.SelectedValue, 0);
            model.call_index = txtCallIndex.Text.Trim();
            model.title = txtTitle.Text.Trim();
            model.link_url = txtLinkUrl.Text.Trim();
            model.img_url = txtImgUrl.Text;
            model.seo_title = txtSeoTitle.Text.Trim();
            model.seo_keywords = txtSeoKeywords.Text.Trim();
            model.seo_description = txtSeoDescription.Text.Trim();
            //内容摘要提取内容前255个字符
            if (string.IsNullOrEmpty(txtZhaiyao.Text.Trim()))
            {
                model.zhaiyao = Utils.DropHTML(txtContent.Value, 255);
            }
            else
            {
                model.zhaiyao = Utils.DropHTML(txtZhaiyao.Text, 255);
            }
            model.content = txtContent.Value;
            model.sort_id = Utils.StrToInt(txtSortId.Text.Trim(), 99);
            model.click = int.Parse(txtClick.Text.Trim());
            model.status = Utils.StrToInt(rblStatus.SelectedValue, 0);
            model.is_msg = 0;
            model.is_top = 0;
            model.is_red = 0;
            model.is_hot = 0;
            model.is_slide = 0;
            if (cblItem.Items[0].Selected == true)
            {
                model.is_msg = 1;
            }
            if (cblItem.Items[1].Selected == true)
            {
                model.is_top = 1;
            }
            if (cblItem.Items[2].Selected == true)
            {
                model.is_red = 1;
            }
            if (cblItem.Items[3].Selected == true)
            {
                model.is_hot = 1;
            }
            if (cblItem.Items[4].Selected == true)
            {
                model.is_slide = 1;
            }
            model.add_time = Utils.StrToDateTime(txtAddTime.Text.Trim());
            model.update_time = DateTime.Now;

            #region 保存相册====================
            //检查是否有自定义图片
            if (txtImgUrl.Text.Trim() == "")
            {
                model.img_url = hidFocusPhoto.Value;
            }
            if (model.albums != null)
            {
                model.albums.Clear();
            }
            string[] albumArr = Request.Form.GetValues("hid_photo_name");
            string[] remarkArr = Request.Form.GetValues("hid_photo_remark");
            if (albumArr != null)
            {
                List<Model.article_albums> ls = new List<Model.article_albums>();
                for (int i = 0; i < albumArr.Length; i++)
                {
                    string[] imgArr = albumArr[i].Split('|');
                    int img_id = Utils.StrToInt(imgArr[0], 0);
                    if (imgArr.Length == 3)
                    {
                        if (!string.IsNullOrEmpty(remarkArr[i]))
                        {
                            ls.Add(new Model.article_albums { id = img_id, article_id = _id, original_path = imgArr[1], thumb_path = imgArr[2], remark = remarkArr[i] });
                        }
                        else
                        {
                            ls.Add(new Model.article_albums { id = img_id, article_id = _id, original_path = imgArr[1], thumb_path = imgArr[2] });
                        }
                    }
                }
                model.albums = ls;
            }
            #endregion

            #region 保存附件====================
            if (model.attach != null)
            {
                model.attach.Clear();
            }
            string[] attachIdArr = Request.Form.GetValues("hid_attach_id");
            string[] attachFileNameArr = Request.Form.GetValues("hid_attach_filename");
            string[] attachFilePathArr = Request.Form.GetValues("hid_attach_filepath");
            string[] attachFileSizeArr = Request.Form.GetValues("hid_attach_filesize");
            string[] attachPointArr = Request.Form.GetValues("txt_attach_point");
            if (attachIdArr != null && attachFileNameArr != null && attachFilePathArr != null && attachFileSizeArr != null && attachPointArr != null
                && attachIdArr.Length > 0 && attachFileNameArr.Length > 0 && attachFilePathArr.Length > 0 && attachFileSizeArr.Length > 0 && attachPointArr.Length > 0)
            {
                List<Model.article_attach> ls = new List<Model.article_attach>();
                for (int i = 0; i < attachFileNameArr.Length; i++)
                {
                    int attachId = Utils.StrToInt(attachIdArr[i], 0);
                    int fileSize = Utils.StrToInt(attachFileSizeArr[i], 0);
                    string fileExt = Utils.GetFileExt(attachFilePathArr[i]);
                    int _point = Utils.StrToInt(attachPointArr[i], 0);
                    ls.Add(new Model.article_attach { id = attachId, article_id = _id, file_name = attachFileNameArr[i], file_path = attachFilePathArr[i], file_size = fileSize, file_ext = fileExt, point = _point, });
                }
                model.attach = ls;
            }
            #endregion


            if (bll.Update(model))
            {

                AddAdminLog(MXEnums.ActionEnum.Edit.ToString(), "修改" + levelName + "内容:" + model.title); //记录日志
                result = true;
            }
            return result;
        }
        #endregion


        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == MXEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel(levelName, MXEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改信息成功！", "ArticleList.aspx?category_id=" + category_id + "&levelName=" + levelName, "Success");
            }
            else //添加
            {
                ChkAdminLevel(levelName, MXEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加信息成功！", "ArticleList.aspx?category_id=" + category_id+"&levelName="+levelName, "Success");
            }
        }
    }
}