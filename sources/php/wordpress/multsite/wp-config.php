<?php
/**
 * The base configurations of the WordPress.
 *
 * This file has the following configurations: MySQL settings, Table Prefix,
 * Secret Keys, and ABSPATH. You can find more information by visiting
 * {@link https://codex.wordpress.org/Editing_wp-config.php Editing wp-config.php}
 * Codex page. You can get the MySQL settings from your web host.
 *
 * This file is used by the wp-config.php creation script during the
 * installation. You don't have to use the web site, you can just copy this file
 * to "wp-config.php" and fill in the values.
 *
 * @package WordPress
 */

// ** MySQL settings - You can get this info from your web host ** //
/** The name of the database for WordPress */
define('DB_NAME', 'wordpress_multsite');

/** MySQL database username */
define('DB_USER', 'root');

/** MySQL database password */
define('DB_PASSWORD', 'MySQL@123456');

/** MySQL hostname */
define('DB_HOST', '127.0.0.1');

/** Database Charset to use in creating database tables. */
define('DB_CHARSET', 'utf8');

/** The Database Collate type. Don't change this if in doubt. */
define('DB_COLLATE', '');

/**#@+
 * Authentication Unique Keys and Salts.
 *
 * Change these to different unique phrases!
 * You can generate these using the {@link https://api.wordpress.org/secret-key/1.1/salt/ WordPress.org secret-key service}
 * You can change these at any point in time to invalidate all existing cookies. This will force all users to have to log in again.
 *
 * @since 2.6.0
 */
define('AUTH_KEY',         'WP||@}x?;t P9VhWI#yNOHJ05zVg 4E?a`N8sYb&kfT2-b63sIA%2Nj~3|g5+ Jx');
define('SECURE_AUTH_KEY',  'o}+i~N>>u+3)@a?[b6g&1EPVx8K)-)2G<5kaRiL*USA=FSI(QWT>)lK[W*8_fx+y');
define('LOGGED_IN_KEY',    'ZHfiDOy}wtf{Tsv( nmS53:r>g24FlsO55B-uIy?6h&RMr>siZ.u@XXcCs+:R,2R');
define('NONCE_KEY',        '`Z-.tTBI!p$(Qqf,?++En>V6MB}`gGE7-d}1F5.)7x8 -zAc<iNF%q/%ylI:Nq H');
define('AUTH_SALT',        'BYmZVfwT-Bg@by.IO5)XcOyWhM~vWeu+hDvtT:%6,/Nzv{9=L(&o@nBQ6#gDS=XH');
define('SECURE_AUTH_SALT', 'F?1-LTrz?~-TR:Tp-Ln97xJn%P^r<N#rn?&IHXIr#6O^efKZZLmo>x$nSrT-$Oh-');
define('LOGGED_IN_SALT',   'yPZNw5W}Ri8C0`7DuWj1T(;cB tg]F9zwLnJ$`Mn3z^/O;Tou#:Pn]8ek36}c?K+');
define('NONCE_SALT',       '~Vl}Q9MA*+n3F*HYS0kl395T+_%C8z{%BnU(YHX..gkTnz !3RsQk~4~{21l|g{q');

/**#@-*/

/**
 * WordPress Database Table prefix.
 *
 * You can have multiple installations in one database if you give each a unique
 * prefix. Only numbers, letters, and underscores please!
 */
$table_prefix  = 'wp_';

/**
 * For developers: WordPress debugging mode.
 *
 * Change this to true to enable the display of notices during development.
 * It is strongly recommended that plugin and theme developers use WP_DEBUG
 * in their development environments.
 */
 /* Default Configuration */
define('WP_DEBUG', false);

/* Mult Site Configuration */
/* Ativação do WordPress Mult Site */
define('WP_ALLOW_MULTISITE', true);

/* Configuração da Rede do WordPress Mult Site (Inserir essas configurações após ter configurado o Network Settings no admin) */
define('MULTISITE', true);
define('SUBDOMAIN_INSTALL', false);
define('DOMAIN_CURRENT_SITE', 'dev.wordpress.com');
define('PATH_CURRENT_SITE', '/');
define('SITE_ID_CURRENT_SITE', 1);
define('BLOG_ID_CURRENT_SITE', 1);

/* That's all, stop editing! Happy blogging. */

/** Absolute path to the WordPress directory. */
if ( !defined('ABSPATH') )
	define('ABSPATH', dirname(__FILE__) . '/');

/** Sets up WordPress vars and included files. */
require_once(ABSPATH . 'wp-settings.php');
