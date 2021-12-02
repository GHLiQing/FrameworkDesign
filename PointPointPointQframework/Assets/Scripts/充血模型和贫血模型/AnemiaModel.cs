using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace SYFramework
{

	public class Player
	{
		public string Name { get; set; }

		public int Id { get; set; }

		public int Age { get; set; }

		public int Number { get; set; }
	}

	public class NeedPlayerInfo
	{
		public string Name { get; set; }
		public int Id { get; set; }
	}

	/// <summary>
	/// 贫血模型 和充血模型
	/// 贫血模型：需要什么数据直接筛选数据 然后获取的数据有需要的也有不需要的 数据冗余度比较搞
	/// 充血模型：需要什么数据直接筛选数据 然后获取的数据都是需要的 数据都可用性很高
	/// </summary>
	public class AnemiaModel : MonoBehaviour
	{
		private List<Player> players = new List<Player>()
		{
			new Player(){ Name="小智", Age=10, Id=1, Number=110},
			new Player(){ Name="小明", Age=110, Id=2, Number=120},
			new Player(){ Name="小黑", Age=10, Id=10, Number=1010},
			new Player(){ Name="小红", Age=10, Id=16, Number=11040},
			new Player(){ Name="小白", Age=10, Id=40, Number=110890},
		};

		private void Awake()
		{

			
			NeedPlayerInfo playerInfo = PlayerInfo_1(10);
			Debug.Log("充血模型:");
			Debug.Log("玩家姓名："+playerInfo.Name+"  id:"+playerInfo.Id);

			Player player = PlayerInfo_2(40);
			Debug.Log("贫血模型:");
			Debug.Log("玩家姓名：" + player.Name );
		}

		/// <summary>
		/// 充血模型
		/// 需要什么数据返回什么数据
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public NeedPlayerInfo PlayerInfo_1(int id)
		{
			return players.Where(p => p.Id == id).Select(p => new NeedPlayerInfo
			{
				Id = p.Id,
				Name = p.Name

			}).FirstOrDefault();
		}

		/// <summary>
		/// 贫血模型
		/// 获得一整个数据 可能有需要的也有不需要的数据
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Player PlayerInfo_2(int id)
		{
			return players.Where(p => p.Id == id).FirstOrDefault();
		}
	}

}
