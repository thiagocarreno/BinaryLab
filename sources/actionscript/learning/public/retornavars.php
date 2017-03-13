<?php
	
	require_once("conexao.php");
	
	$query = mysql_query("SELECT nome, mensagem FROM cadastro");
	
	$i = 0;
	
	while($n = mysql_fetch_array($query))
	{
		if($i > 0) echo "&nome$i=" . $n["nome"];
		
		else echo "nome$i=" . $n["nome"];
		
		echo "&mensagem$i=" . $n["mensagem"]; $i++;
	}
	
	echo "&total=" . $i;
	
?>