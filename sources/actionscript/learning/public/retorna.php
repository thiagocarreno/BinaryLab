<?php

require_once( "conexao.php" );

$query = mysql_query( "SELECT nome, mensagem FROM cadastro" );

while( $n = mysql_fetch_array($query) )
{
	echo $n["nome"]; echo $n["mensagem"];
}

?>