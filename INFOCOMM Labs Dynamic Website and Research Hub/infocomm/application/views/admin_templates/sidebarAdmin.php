<?php
	if($this->session->userdata('userID') == ''){
		header("location: ".base_url()."admin/login");
	}else{ 
		$adminAction = '';
		if($this->session->userdata('accessLevel') == 2){
			$adminAction = '';
		}else{
			$adminAction = '
			<li>
			  <a href="'.base_url().'admin/publications">
				<i class="fa fa-file-text"></i> <span>Publications</span>
			  </a>
			</li>
			<li class="treeview">
			  <a href="#">
				<i class="fa fa-users"></i> <span>Collaborators</span>
				<span class="pull-right-container">
				  <i class="fa fa-angle-left pull-right"></i>
				</span>
			  </a>
			  <ul class="treeview-menu">
				<li><a href="'.base_url().'admin/addCollaborators"><i class="fa fa-angle-double-right"></i> Add Collaborators</a></li>
				<li><a href="'.base_url().'admin/collaborators"><i class="fa fa-angle-double-right"></i> View Collaborators </a></li>
			  </ul>
			</li>
			<li class="treeview">
			  <a href="#">
				<i class="fa fa-list-alt"></i> <span>Vacancies</span>
				<span class="pull-right-container">
				  <i class="fa fa-angle-left pull-right"></i>
				</span>
			  </a>
			  <ul class="treeview-menu">
				<li><a href="'.base_url().'admin/viewVacancies"><i class="fa fa-angle-double-right"></i> View </a></li>
				<li><a href="'.base_url().'admin/addVacancies"><i class="fa fa-angle-double-right"></i> Add </a></li>
				<li><a href="'.base_url().'admin/applications"><i class="fa fa-angle-double-right"></i> Applications </a></li>
			  </ul>
			</li>';
		}
	}
?>
<aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
      <ul class="sidebar-menu">
        <li class="header">MAIN NAVIGATION</li>
        <li class="active">
          <a id="sideLink" href="<?php echo base_url(); ?>admin/index">
            <i class="fa fa-dashboard"></i> <span>Dashboard</span>
          </a>
        </li>
        <li>
          <a href="<?php echo base_url(); ?>admin/users">
            <i class="fa fa-user"></i> <span>Users</span>
          </a>
        </li>
        <li>
          <a href="<?php echo base_url(); ?>admin/categories">
            <i class="fa fa-list"></i> <span>Categories</span>
          </a>
        </li>
        <li>
		  <a href="<?php echo base_url(); ?>admin/reports">
			<i class="fa fa-registered"></i> <span>Reports</span>
		  </a>
		</li>
		<li>
          <a href="<?php echo base_url(); ?>admin/projects">
            <i class="fa fa-folder"></i> <span>Projects</span>
          </a>
        </li>
        <?php echo $adminAction; ?>
        <li class="treeview">
          <a href="#">
            <i class="fa fa-calendar"></i> <span>Events</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="<?php echo base_url(); ?>admin/addEvents"><i class="fa fa-calendar"></i> Add Events </a></li>
            <li><a href="<?php echo base_url(); ?>admin/events"><i class="fa fa-calendar"></i> View Events </a></li>
          </ul>
        </li>
        <li class="treeview">
          <a href="#">
            <i class="fa fa-newspaper-o"></i> <span>News</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
           <li><a href="<?php echo base_url(); ?>admin/addNews"><i class="fa fa-newspaper-o"></i> Add News </a></li>
            <li><a href="<?php echo base_url(); ?>admin/news"><i class="fa fa-newspaper-o"></i> View News </a></li>
          </ul>
        </li>
        <li class="treeview">
          <a href="#">
            <i class="fa fa-list-alt"></i> <span>Static Pages</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="<?php echo base_url(); ?>admin/contact"><i class="fa fa-angle-double-right"></i> Edit Contact </a></li>
            <li><a href="<?php echo base_url(); ?>admin/editAbout"><i class="fa fa-angle-double-right"></i> Edit About Us </a></li>
            <li><a href="<?php echo base_url(); ?>admin/ourTeamCategories"><i class="fa fa-angle-double-right"></i> Edit Our Team </a></li>
            <li><a href="<?php echo base_url(); ?>admin/termsAndConditions"><i class="fa fa-angle-double-right"></i> Edit T&amp;C</a></li>
          </ul>
        </li>
        <!--<li>
          <a href="<?php //echo base_url(); ?>admin/staticPages">
            <i class="fa fa-edit"></i> <span>Static Pages</span>
          </a>
        </li>-->
        <!--
        <li>
          <a href="<?php echo base_url(); ?>index.php/pages/mailbox/mailbox.html">
            <i class="fa fa-envelope"></i> <span>Mailbox</span>
            <span class="pull-right-container">
              <small class="label pull-right bg-yellow">12</small>
              <small class="label pull-right bg-green">16</small>
              <small class="label pull-right bg-red">5</small>
            </span>
          </a>
        </li>_-->
        <!--
        <li class="treeview">
          <a href="#">
            <i class="fa fa-share"></i> <span>Multilevel</span>
            <span class="pull-right-container">
              <i class="fa fa-angle-left pull-right"></i>
            </span>
          </a>
          <ul class="treeview-menu">
            <li><a href="#"><i class="fa fa-circle-o"></i> Level One</a></li>
            <li>
              <a href="#"><i class="fa fa-circle-o"></i> Level One
                <span class="pull-right-container">
                  <i class="fa fa-angle-left pull-right"></i>
                </span>
              </a>
              <ul class="treeview-menu">
                <li><a href="#"><i class="fa fa-circle-o"></i> Level Two</a></li>
                <li>
                  <a href="#"><i class="fa fa-circle-o"></i> Level Two
                    <span class="pull-right-container">
                      <i class="fa fa-angle-left pull-right"></i>
                    </span>
                  </a>
                  <ul class="treeview-menu">
                    <li><a href="#"><i class="fa fa-circle-o"></i> Level Three</a></li>
                    <li><a href="#"><i class="fa fa-circle-o"></i> Level Three</a></li>
                  </ul>
                </li>
              </ul>
            </li>
            <li><a href="#"><i class="fa fa-circle-o"></i> Level One</a></li>
          </ul>
        </li>
        -->
      </ul>
    </section>
    <!-- /.sidebar -->
  </aside>
