using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Common;
namespace BLL {
	 	//管理员表
		public partial class dt_manager:dt_managerBase
	{
   		     
		private readonly DAL.dt_manager dal=new DAL.dt_manager();
		public dt_manager():base()
		{}
		#region 扩展方法
             /// <summary>
        /// 查询用户名是否存在
        /// </summary>
        public bool Exists(string user_name)
        {
            return dal.Exists(user_name);
        }
             /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.dt_manager GetModel(string user_name, string password)
        {
            return dal.GetModel(user_name,password);
        }
        /// <summary>
        /// 根据用户名密码返回一个实体
        /// </summary>
        public Model.dt_manager GetModel(string user_name, string password, bool is_encrypt)
        {
            //检查一下是否需要加密
            if (is_encrypt)
            {
                //先取得该用户的随机密钥
                string salt = dal.GetSalt(user_name);
                if (string.IsNullOrEmpty(salt))
                {
                    return null;
                }
                //把明文进行加密重新赋值
                password = DESEncrypt.Encrypt(password, salt);
            }
            return dal.GetModel(user_name, password);
        }
             /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize,pageIndex,strWhere,filedOrder,out recordCount);
        }
        #endregion
	}
}