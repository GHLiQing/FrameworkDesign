四层架构：
View ；负责UI
System :负责提供api又有状态的对象 比如网络服务，蓝牙服务，商城系统
Model ：管理数据 有状态，提供数据的增删改查
Utility ： 无状态，提供一些必备的基础工具，比如数据存储，网络链接，蓝牙，序列化和反序列化

自下而上的使用规则：
model可以调用Utility
system可以调用model Utility
view(command) 可以调用 system model 一般不可以调用Utility

四层架构添加对应的约束

表现逻辑：view-> model
使用command
交互逻辑：model -> view
使用委托事件


每个游戏需要创建一个app类 继承Architecture 类 ，注册相关的model，system 
每个model 需要继承 abstractModel类和IModel类 而model需要定义一个对应的接口 添加对应的属性 方法即可
例如：
public interface IPlayerModel : IModel
	{
	   BindableProprety<int> HP { get; }
	}

	//继承抽象类和对象接口
	public class PlayerModel : AbstractModel, IPlayerModel
	{
		
		protected override void OnInit()
		{
			
		}

		public BindableProprety<int> HP { get; } = new BindableProprety<int>()
		{
			Valuse = 3
		};
	}

每个system和model类似 需要继承abstrSystem类
每个command 使用是一样的 


工具： 
BindableProprety属性类 
EventSystem类
single类

/*
架构理解：
Architecture和每个model ,system ,view, utility 互相持有的关系

*/