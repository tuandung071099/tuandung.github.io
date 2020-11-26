<style>


	#logo h1 a {
		text-align: left;
		font-size: 58pt;
		margin-top: -28px;
	}

	.searchBox input {
		border: 1px solid black;
		line-height: 25px;
		min-width: 262px;
		height: 25px;
		float: left;
		margin-top: -44px;
		margin-left: 30px
	}

	.searchBox>a>img {
		background-position: -73px -83px;
		width: 20px;
		height: 20px;
		margin: -41px 0px 0px 267px;
		float: left;
		
	}
	

	.searchBox i:hover {
		color: #2cb7ab;
	}

	.icon,
	img[class^=icon] {
		background-repeat: no-repeat;
		display: inline-block;
		vertical-align: text-top;
	}

	#content img {
		border: #ffffff;
	}
</style>
<script type="text/javascript">
	function searchEnter(){		
		var str = document.getElementById("txtSearch").value;
		if (str == "") {			
			window.alert("Vui lòng gõ từ khóa tìm kiếm!");
		} else {
			window.location.href = "tim_kiem.php?search=" + str;
		}
	}
</script>
<div id="header-wrapper">
	<header id="header">
		<div class="5grid-layout">
			<div class="row">
				<div class="12u" id="menu">
					<div id="menu-wrapper">
						<div class="12u" id="logo">
							<!-- Logo -->
							<h1><a href="index.php" class="mobileUI-site-name">read so much</a></h1>
							<ul>
								<li><a href="./index.php">Trang chủ</a></li>
								<li><a href="./loai_tai_lieu.php">Danh mục phân loại</a></li>
								<li><a href="./dong_gop.php">Đóng góp</a></li>
								<li><a href="./lien_he.php">Liên hệ</a></li>
							</ul>
							<div class="searchBox">
								<input type="text" id="txtSearch" gtm-element="GTM_Search_Click_Searchbox" gtm-label="GTM_Search_Click_Searchbox" placeholder="Tìm kiếm ..." name="txtSearch" autocomplete="off">
								<a href="javascript:;" id="GTM_Search_Search" rel="nofollow" onclick="searchEnter();"><img class="icon icon_search" src="./images/search.ico" width="500" height="600"></a>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</header>
</div>