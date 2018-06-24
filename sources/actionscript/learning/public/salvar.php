<?php

require_once( "conexao.php" );


$nome = utf8_decode( $_POST['nome'] );

$mensagem = utf8_decode( $_POST['mensagem'] );


$query = mysql_query("INSERT INTO cadastro ( nome, mensagem ) VALUES ( '$nome','$mensagem' )");


echo "sucesso=" . $query;

?>