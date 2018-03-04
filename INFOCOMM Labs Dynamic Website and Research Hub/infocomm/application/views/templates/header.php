<?php
$baseURL = base_url();
	$userID = '';
	if($this->session->userdata('userID') == ''){
		$loginOutput = '<button id="loginLink" style="margin-top:7px;" class="btn btn-default" role="button">Login</button><button id="registerLink" style="margin-top:7px; margin-left:5px;" class="btn btn-default">Register</button>';
		$notification = '';
	}else{
		$userID = $this->session->userdata('userID');
		
		$this->db->select('*');
		$this->db->from('users');
		$this->db->where('userID', $userID);
		$this->db->where('status', 'Activated');
		
		$query = $this->db->get();
		$output = $query->result();
		foreach($output as $result){
			$titlee = $result->title;
			$fname = $result->fname;
			$lname = $result->lname;
			$dateJoined = $result->dateJoined;
		}
		$notification = '<a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <i class="fa fa-bell-o"></i>
                <span class="label label-warning label-notification"></span>
              </a>';
			  
		$loginOutput = '<a href="#" class="dropdown-toggle" data-toggle="dropdown">
                <!-- The user image in the navbar-->
                <img src="'.$baseURL.'dist/img/user3-128x128.jpg" class="user-image" alt="User Image">
                <!-- hidden-xs hides the username on small devices so only the image appears. -->
                <span class="hidden-xs">'.$titlee.' '.$fname.'</span>
              </a>';
	}
?>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">

  <title><?php echo $title ?></title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="<?php echo base_url() ?>bootstrap/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
  <link rel="stylesheet" href="<?php echo base_url() ?>dist/css/style.css">
  <link rel="stylesheet" href="<?php echo base_url() ?>dist/css/footer.css">
  <link rel="stylesheet" href="<?php echo base_url() ?>dist/css/profile.css">
  <link rel="stylesheet" href="<?php echo base_url() ?>dist/css/livesearch.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="<?php echo base_url() ?>dist/css/AdminLTE.min.css">
  <!-- AdminLTE Skins. Choose a skin from the css/skins
       folder instead of downloading all of them to reduce the load. -->
  <link rel="stylesheet" href="<?php echo base_url() ?>dist/css/skins/_all-skins.min.css">
  <!-- DataTables -->
  <link rel="stylesheet" href="<?php echo base_url(); ?>plugins/datatables/dataTables.bootstrap.css">
  <link rel="stylesheet" href="<?php echo base_url() ?>dist/css/project_style.css">
  <link rel="stylesheet" href="//code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
  
</head>

<body class="hold-transition skin-green layout-top-nav">
<div class="wrapper">

  <header class="main-header">
    <nav class="navbar navbar-static-top">
      <div class="container">
        <div class="navbar-header" >
          <a href="<?php echo base_url();?>" class="navbar-brand"><b>Infocomm</b></a>
          <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar-collapse">
            <i class="fa fa-bars"></i>
          </button>
        </div>
		<input id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
        <input id="isLoggedIn" type="hidden" value="<?php echo $userID ?>" />
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse pull-left" id="navbar-collapse">
          <ul class="nav navbar-nav">
            <li><a href="<?php echo base_url();?>about">About <span class="sr-only">(current)</span></a></li>
            <li><a href="<?php echo base_url();?>projects">Projects <span class="sr-only">(current)</span></a></li>
           	<li><a href="<?php echo base_url();?>viewPublications">Publications <span class="sr-only">(current)</span></a></li>
            <li><a href="<?php echo base_url();?>ourTeam">Team <span class="sr-only">(current)</span></a></li>
            <li><a href="<?php echo base_url();?>news">News <span class="sr-only">(current)</span></a></li>
            <li><a href="<?php echo base_url();?>events">Events <span class="sr-only">(current)</span></a></li>
            <li><a href="<?php echo base_url();?>vacancies">Vacancies <span class="sr-only">(current)</span></a></li>
            <li><a href="<?php echo base_url();?>contact">Contact Us <span class="sr-only">(current)</span></a></li>
          <div class="navbar-form navbar-left">
            <div class="form-group">
              <input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />                                
              <input type="text" class="form-control pull-left" autocomplete="off" style="width:auto; margin-right:5px;" id="navbar-search-input" placeholder="Enter search term">
			  <ul class="searchup">
				  <span id="nav-search-results"></span>
			  </ul>
            </div>
          </div>
        </div>
        <!-- /.navbar-collapse -->
        <!-- Navbar Right Menu -->
        <div class="navbar-custom-menu">
          <ul class="nav navbar-nav">
            <!-- Messages: style can be found in dropdown.less-->
            
            <!-- /.messages-menu -->

            <!-- Notifications Menu -->
            <li class="dropdown notifications-menu">
              <!-- Menu toggle button -->
              <?php echo $notification ?>
              <ul class="dropdown-menu">
                <li class="header header-notification"></li>
                <li>
                  <!-- Inner Menu: contains the notifications -->
                  <ul class="menu notification-infocomm">
                  <!-- start notification -->
                    
                    <!-- end notification -->
                  </ul>
                </li>
                <li class="footer"><a href="#">View all</a></li>
              </ul>
            </li>
            <!-- Tasks Menu -->
            
            <!-- User Account Menu -->
            <li class="dropdown user user-menu">
              <!-- Menu Toggle Button -->
              <?php echo $loginOutput ?>
              
              <ul class="dropdown-menu">
                <!-- The user image in the menu -->
                <li class="user-header">
                  <img src="<?php echo base_url() ?>dist/img/user3-128x128.jpg" class="img-circle" alt="User Image">

                  <p>
                    <?php echo $titlee.' '.$fname.' '.$lname.' 
                    <small>Member since '.date('jS F, Y', strtotime($dateJoined)).'</small>';
					?>
                  </p>
                </li>
                <!-- Menu Body -->
                <li class="user-body">
                  <div class="row">
                    <div class="col-xs-6 text-center">
                      <a href="#">Followers</a>
                    </div>
                    <div class="col-xs-6 text-center headerFollowers">
                      	
                    </div>
                  </div>
                  <!-- /.row -->
                </li>
                <!-- Menu Footer-->
                <li class="user-footer">
                  <div class="pull-left">
                    <a href="<?php echo base_url();?>user/profile" class="btn btn-default btn-flat">Profile</a>
                  </div>
                  <div class="pull-right">
                    <a href="<?php echo base_url();?>logout/logout" class="btn btn-default btn-flat">Sign out</a>
                  </div>
                </li>
              </ul>
            </li>
          </ul>
        </div>
        <!-- /.navbar-custom-menu -->
      </div>
      <!-- /.container-fluid -->
    </nav>
  </header>