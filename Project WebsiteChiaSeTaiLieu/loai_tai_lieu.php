<!DOCTYPE HTML>
<!--
	Affinity by TEMPLATED
	templated.co @templatedco
	Released for free under the Creative Commons Attribution 3.0 license (templated.co/license)
-->
<html>
<head>
	<title>Danh mục chủ đề theo thể loại</title>
	<meta http-equiv="content-type" content="text/html; charset=utf-8" />
	<meta name="description" content="" />
	<meta name="keywords" content="" />	
	<link rel="icon" href="images/fav.ico">
	<noscript>
		<link rel="stylesheet" href="css/5grid/core.css" />
		<link rel="stylesheet" href="css/5grid/core-desktop.css" />
		<link rel="stylesheet" href="css/5grid/core-1200px.css" />
		<link rel="stylesheet" href="css/5grid/core-noscript.css" />
		<link rel="stylesheet" href="css/style.css" />
		<link rel="stylesheet" href="css/style-desktop.css" />
	</noscript>
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.2/jquery.min.js"></script>
	<script src="css/5grid/init.js?use=mobile,desktop,1000px&amp;mobileUI=1&amp;mobileUI.theme=none"></script>
	<style type="text/css">
		.catedirec{float:left;margin-left:5px;margin-bottom:5px;}
		.ulkey{width:1174px;margin-top:5px;padding-left:6px;}
		.ulkey li{background:url(images/icontag9x9.gif) no-repeat 0px 5px;width:330px;padding-left:15px;float:left;line-height:20px;}
		ul {
			display: block;
			margin-block-start: 1em;
			margin-inline-start: 0px;
			margin-inline-end: 0px;
			padding-inline-start: 40px;
		}
		ul a {
			text-decoration: none;
		}
	</style>
	<!--[if IE 9]><link rel="stylesheet" href="css/style-ie9.css" /><![endif]-->
</head><body>
	<div id="wrapper">
		<?php
		$conn = mysqli_connect("remotemysql.com:3306", "MFjxl5C769", "4yl0CnAF1W", "MFjxl5C769");
		?>	
		<?php
		include("header.php");
		;?>
		<div id="page-wrapper" class="5grid-layout">
			<div class="5grid-layout">
				<div class="row">
					<div class="6u">
						<div id="content">
							<section>
								<div>
									<h1 style="font-size: 24px;"><b>Phân loại chủ đề</b></h1>
									<div>
										<ul>
											<?php
											$sql = "
											SELECT *
											FROM loai_tai_lieu	
											";
											$loaitl = mysqli_query($conn, $sql);
											while ($row = mysqli_fetch_array($loaitl)) {												
												$maLoai = $row["id_loai_tai_lieu"];
												;?>
												<li class = "catedirec" style="font-size: 16; padding-bottom: -0.7px"><h2>
													<a href="chu_de.php?id=&id2=<?php echo $maLoai?>">
														<?php echo $row["ten_loai_tai_lieu"];?>															
													</a></h2>
													<ul class = "ulkey">												
														<?php
														$sql2 = "
														SELECT *
														FROM chu_de
														WHERE id_loai_tai_lieu = $maLoai
														";
														$dsChuDe = mysqli_query($conn, $sql2);
														while ($row = mysqli_fetch_array($dsChuDe)) {
															;?>
															<li>
																<a href="chu_de.php?id=<?php echo $row["id_chu_de"]?>&id2=<?php echo $maLoai?>"><?php echo $row["ten_chu_de"];?></a>
															</li>
															<?php
														}
														;?>
													</ul>														
												</li>
												<?php
											}
											;?>
										</ul>
									</div>
								</div>
							</section>
							<section>
							</section>
						</div>
					</div>
					<div class="3u" id="sidebar1">
						<section>
						</section>
						<section>
						</section>
					</div>
					<div class="3u">
						<div id="sidebar2">
							<section>
								<div class="sbox1">
								</div>
								<div class="sbox2">
								</div>
							</section>
						</div>
					</div>
				</div>
			</div>
		</div>
		<?php
			include("footer.php");
		;?>
</body>
</html>