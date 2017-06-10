<?php

class geral
{
	private $host;
	
	private $user;
	
	private $database;
	
	private $pass;
	
	
	public function geral()
	{
		require_once( "config.php" );
		
		$this->host = DB_HOST;
		
		$this->user = DB_USER;
		
		$this->pass = DB_PASS;
		
		$this->database = DB_NAME;
	}
	
	private function connect()
	{
		mysql_connect( $this->host,$this->user,$this->pass );
		
		mysql_select_db( $this->database );
	}
	
	public function retornar( $dados = array() )
	{
		$this->connect();
		
		$query = mysql_query( "SELECT nome, mensagem FROM cadastro" );
		
		$dados = array();
		
		while($n = mysql_fetch_array($query))
		{
			$dados[] = array( $n['nome'], $n['mensagem'] );
		}
		
		return $dados;
	}
	
	public function salvar( $dados = array() )
	{
		$this->connect();
		
		$nome = utf8_decode( $dados[0] );

		$mensagem = utf8_decode( $dados[1] );
		
		
		$query = mysql_query("INSERT INTO cadastro ( nome, mensagem ) VALUES ( '$nome','$mensagem' )");
		
		return 'RETORNO';
	}
}

?>