<?php

require_once( "config.php" );

$conexao = mysql_connect( DB_HOST, DB_USER, DB_PASS );

$conexaoDB = mysql_select_db( DB_NAME, $conexao );

?>