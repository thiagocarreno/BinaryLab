//Chama resposta de origem
/*
package teste
	{
		public class customFullDef extends fullDef
			{
			public function customFullDef()
			{
			super();
			}
		}
	}
*/
//Chama resposta de origem e a substitui (override) desde que essa classe seja publica (public)
package teste
	{
		public class customFullDef extends fullDef
			{
				public function customFullDef()
				{
						super();
				}
						override public function painelInfo():String{
						return "Painel Protegido / sem definições";
						}
							
			}
	}