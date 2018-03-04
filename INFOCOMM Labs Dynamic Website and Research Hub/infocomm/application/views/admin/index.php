<?php

//get total activated users
$this->db->where('status','Activated');
$this->db->from("users");
$activatedUsers =  $this->db->count_all_results();

//get total pending users
$this->db->where('status','Pending');
$this->db->from("users");
$pendingUsers =  $this->db->count_all_results();

//get total approved users
$this->db->where('status','Approved');
$this->db->from("users");
$approvedUsers =  $this->db->count_all_results();

//get total suspended users
$this->db->where('status','Suspended');
$this->db->from("users");
$suspendedUsers =  $this->db->count_all_results();

//sets date for today to compare to db
$today = date('Y/m/d');

//gets on-going projects
$this->db->where('startDate <=', $today);
$this->db->where('endDate >=', $today);
$this->db->from("user_projects");
$activateProjects =  $this->db->count_all_results();

//gets upcoming events
$this->db->where('date >=', $today);
$this->db->from("events");
$upcomingEvents =  $this->db->count_all_results();

//gets open vacancies
$this->db->where('dateCreated <=', $today);
$this->db->where('deadline >=', $today);
$this->db->from("vacancies");
$vacancies =  $this->db->count_all_results();

//gets the dats to filter through new and active users
$thisMonth = date('Y/m/01');
$weekAgo = date('Y/m/d', strtotime("7 days ago"));

//gets new users this month
$this->db->where('dateJoined <=', $today);
$this->db->where('dateJoined >=', $thisMonth);
$this->db->from("users");
$newUsersThisMonth =  $this->db->count_all_results();

//total users
$this->db->from("users");
$totalUsers =  $this->db->count_all_results();

//gets active users
$this->db->where('lastLogin >=', $weekAgo);
$this->db->from("users");
$activeUsers =  $this->db->count_all_results();

$activePercent = $activatedUsers / $totalUsers * 100;

?>
  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Dashboard
        <small>Control panel</small>
      </h1>
      <ol class="breadcrumb">
        <li><a href="#"><i class="fa fa-dashboard"></i> Home</a></li>
        <li class="active">Dashboard</li>
      </ol>
    </section>

    <!-- Main content -->
    <section class="content">
    <div class="box box-solid">	
      <div class="box-header">
	      <i class="fa fa-bar-chart-o"></i>
	
	      <div class="box-tools pull-right">
	        <button type="button" class="btn btn-default btn-sm" data-widget="collapse"><i class="fa fa-minus"></i>
	        </button>
	      </div>
	    </div>
      <div class="box-body">
      <!-- Small boxes (Stat box) -->
      <div class="row">
        <div class="col-lg-1"></div>
        
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-yellow text-center">
            <div class="inner">
              <h3><?php echo $pendingUsers; ?></h3>
              <p>Pending User(s)</p>
            </div>
            <a href="<?php echo base_url(); ?>admin/users" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-primary text-center">
            <div class="inner">
              <h3><?php echo $activatedUsers; ?></h3>
              <p>Actived User(s)</p>
            </div>
            <a href="<?php echo base_url(); ?>admin/users" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-green text-center">
            <div class="inner">
              <h3><?php echo $approvedUsers; ?></h3>
              <p>Approved User(s)</p>
            </div>
            <a href="<?php echo base_url(); ?>admin/users" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-red text-center">
            <div class="inner">
              <h3><?php echo $suspendedUsers; ?></h3>
              <p>Suspended User(s)</p>
            </div>
            <a href="<?php echo base_url(); ?>admin/users" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-fuchsia text-center">
            <div class="inner">
              <h3><?php echo $newUsersThisMonth; ?></h3>
              <p>New User(s)</p>
            </div>
            <a href="<?php echo base_url(); ?>admin/users" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        
      </div>
      <!-- /.row -->
      
            <!-- Small boxes (Stat box) -->
      <div class="row">
        <div class="col-lg-3"></div>
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-lime text-center">
            <div class="inner">
              <h3><?php echo $activateProjects; ?></h3>
              <p>Active Project(s)</p>
            </div>
            <a href="<?php echo base_url(); ?>admin/projects" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-aqua text-center">
            <div class="inner">
              <h3><?php echo $upcomingEvents; ?></h3>
              <p>Upcoming Event(s)</p>
            </div>
            <a href="<?php echo base_url(); ?>admin/events" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
        
        <div class="col-lg-2 col-xs-6">
          <!-- small box -->
          <div class="small-box bg-purple text-center">
            <div class="inner">
              <h3><?php echo $vacancies; ?></h3>
              <p>Open Vacancies</p>
            </div>
            <a href="<?php echo base_url(); ?>admin/viewVacancies" class="small-box-footer">More info <i class="fa fa-arrow-circle-right"></i></a>
          </div>
        </div>
        <!-- ./col -->
      </div>
      <!-- /.row -->
  	</div></div>
      
      <!-- row -->
      <div class="row">
        <div class="col-xs-12">
          <!-- jQuery Knob -->
          <div class="box box-solid">
            <div class="box-header">
              <i class="fa fa-pie-chart"></i>

              <div class="box-tools pull-right">
                <button type="button" class="btn btn-default btn-sm" data-widget="collapse"><i class="fa fa-minus"></i>
                </button>
              </div>
            </div>
            <!-- /.box-header -->
            <div class="box-body">
              <div class="row">
                <div class="col-md-12 text-center">
                  <input type="text" class="knob" value="<?php echo $activePercent; ?>" data-width="250" data-height="250" data-fgColor="#3c8dbc" readonly>

                  <div class="knob-label">Percentage of Active Users</div>
                </div>
                <!-- ./col -->
              </div>
              <!-- /.row -->
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->



    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->
  
 <!-- ./wrapper -->

<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url();?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- jQuery UI 1.11.4 -->
<script src="https://code.jquery.com/ui/1.11.4/jquery-ui.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url();?>bootstrap/js/bootstrap.min.js"></script>
<!-- jQuery Knob Chart -->
<script src="<?php echo base_url();?>plugins/knob/jquery.knob.js"></script>
<!-- daterangepicker -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.11.2/moment.min.js"></script>
<script src="<?php echo base_url();?>plugins/daterangepicker/daterangepicker.js"></script>
<!-- Bootstrap WYSIHTML5 -->
<script src="<?php echo base_url();?>plugins/bootstrap-wysihtml5/bootstrap3-wysihtml5.all.min.js"></script>
<!-- AdminLTE App -->
<script src="<?php echo base_url();?>dist/js/app.min.js"></script>
<!-- AdminLTE dashboard demo (This is only for demo purposes) -->
<script src="<?php echo base_url();?>dist/js/pages/dashboard.js"></script>