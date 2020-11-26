<!DOCTYPE HTML>

<html>
<head>
	<title>Đăng nhập</title>
	<meta http-equiv="content-type" content="text/html; charset=utf-8" />
	<meta name="description" content="" />
	<meta name="keywords" content="" />
	<noscript>
		<link rel="stylesheet" href="css/5grid/core.css" />
		<link rel="stylesheet" href="css/5grid/core-desktop.css" />
		<link rel="stylesheet" href="css/5grid/core-1200px.css" />
		<link rel="stylesheet" href="css/5grid/core-noscript.css" />
		<link rel="stylesheet" href="css/style.css" />
		<link rel="stylesheet" href="css/style-desktop.css" />
	</noscript>
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
	<script src="css/5grid/init.js?use=mobile,desktop,1000px&amp;mobileUI=1&amp;mobileUI.theme=none&amp;mobileUI.openerWidth=52"></script>
	<!--[if IE 9]><link rel="stylesheet" href="css/style-ie9.css" /><![endif]-->
	<style>
		form
		{
			display: inline-block;
			margin-left: 32%;
			margin-right:15%;
			width: 70%;
		}
		
		.button 
		{
			display: block;
			width: 51%;
			border: none;
			background-color: #007c8b;;
			padding: 14px 28px;
			font-size: 16px;
			cursor: pointer;
			text-align: center;
			margin-top: 10px
		}
	</style>
</head>
<body class="onecolumn">
	<div id="wrapper">
		
		<?php
			include("header.php");
		;?>
		<div id="page-wrapper" class="5grid-layout">
			<div class="row" id="content">
				<div class="12u">
					<h1 style="font-size: 30px;;text-align: center; font-weight: bold; color: red; padding-bottom: 20px;">ĐĂNG NHẬP HỆ THỐNG</h1>
					<form method="POST" action="./dang_nhap_thuc_hien.php" enctype="multipart/form-data">
						<p>
							Tài khoản:<br>
							<input type="text" name="txtTaiKhoan" style="width: 50%;">
						</p>
						<p>
							Mật khẩu:<br>
							<input type="password" name="txtMatKhau" style="width: 50%;">
						</p>
						<button type="submit" class="button">Đăng nhập</button>
					</form>
				</div>
			</div>
		</div>
		<?php
			include("footer.php");
		;?>
</body>
</html>