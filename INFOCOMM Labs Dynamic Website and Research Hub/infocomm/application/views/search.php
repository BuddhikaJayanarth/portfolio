<?php
$people = '';
$publications = '';
$projects = '';
$vacancies = '';
$events = '';
$news = '';
$filter = 'all';

//gets the key from the search box post
if(isset($_GET['key']) && $_GET['key'] != '')
{
	$key = $_GET['key'];

	//creates the box if the filter is all or people
	if($filter == "all" || $filter == "people") {
		$this->db->select("*");
		$this->db->like('username', "$key");
		$this->db->or_like("concat(fname,' ',lname)", "$key");
		$query = $this->db->get("users");
		$data = $query->result();
		$count = $query->num_rows(); 
		$row = 0;
		
		if($count>0) {
			
			foreach($data as $item)
			{
				if($row == 0 && ($item->status == 'Activated' || $item->status == 'Suspended'))
				{
					$people .= '<div id="peopleBox">
						<div class="box-header with-border">
					      <h3 class="box-title">People</h3>
					    </div>
					    <div class="box-body">';		
				}
				
				$userPicJPG = './resources/profile_image/'.$item->username.'.jpg';
				$userPicPNG = './resources/profile_image/'.$item->username.'.png';
				$userImage = "";
				
				//checks if image exists or else sets to avatar
				if(file_exists($userPicJPG))
				{
					$userImage = base_url().'resources/profile_image/'.$item->username.'.jpg';
				}
				else if(file_exists($userPicPNG))
				{
					$userImage = base_url().'resources/profile_image/'.$item->username.'.png';
				}
				else
				{
					$userImage = base_url().'resources/profile_image/avatar.png';
				}
				  	
				if ($item->status == 'Activated' || $item->status == 'Suspended') {
					$people .='	  
								  
								  	  <!-- result row -->
									  <div class="row">
									  	<div class="col-sm-2">
									  		<img class="img-responsive" src="'.$userImage.'" />
									  	</div>
									  	<div class="col-sm-10">
									  		<h4><a href="'.base_url().'user/profile?user='.$item->username.'">'.$item->fname . ' ' . $item->lname.'</a></h4>
									  		<h5>'.$item->city .', '. $item->country.'</h5>
									  	</div>
								      </div>
								      <hr />
								      <!-- /.result row -->
								  ';
				}
				
				$row++;
				
				if($row == $count && ($item->status == 'Activated' || $item->status == 'Suspended'))
				{
					$people .= '</div></div>';		
				}
			}
			
		}
	}
	
	//creates the box if the filter is all or projects
	if($filter == "all" || $filter == "projects") {
		$this->db->select('*');
		$this->db->from('user_projects');
		$this->db->join('categories_project', 'categories_project.catID = user_projects.catID');
		$this->db->like('projectTitle', "$key");
		$this->db->or_like('description', "$key");
		$this->db->or_like('catName', "$key");
		$query = $this->db->get();
		$data = $query->result();
		$count = $query->num_rows(); 
	
		if($count>0) {
			$projects .='	<div id="projectBox">
							  <div class="box-header with-border">
							      <h3 class="box-title">Projects</h3>
							  </div>
							  <div class="box-body">';
			
			foreach($data as $item)
			{  	
				$projects .='	  	  <!-- result row -->
									  <div class="row">
									  	<div class="col-sm-2">
									  		<img class="img-responsive" src="'.base_url().'/resources/projects/profile_pic/'.$item->projectID.'.jpg" />
									  	</div>
									  	<div class="col-sm-10">
									  		<h4><a href="'.base_url().'user/projectprofile?projid='.$item->projectID.'">'.$item->projectTitle.'</a></h4>
									  		<h5>'.$item->catName.'</h5>
									  	</div>
								      </div>
								      <hr />
								      <!-- /.result row -->
								  ';
			}
			
			$projects .='	</div></div>';
		}
	}
	
	//creates the box if the filter is all or publications
	if($filter == "all" || $filter == "publications") {
		$this->db->select('*');
		$this->db->from('user_publications');
		$this->db->join('categories_project', 'categories_project.catID = user_publications.category');
		$this->db->join('users', 'users.userID = user_publications.userID');
		$this->db->like('pubTitle', "$key");
		$this->db->or_like('catName', "$key");
		$query = $this->db->get();
		$data = $query->result();
		$count = $query->num_rows(); 
	
		if($count>0) {
			$publications .='	<div id="publicationBox">
								  <div class="box-header with-border">
								      <h3 class="box-title">Publications</h3>
								  </div>
								  <div class="box-body">';
			
			foreach($data as $item)
			{
				if($item->status == "Activated")
				{
					if ($item->type == 'Book')
					{
						$icon = '<i class="fa fa-book" style="font-size: 65px; padding-left: 20px;"></i>';
					}
					else if ($item->type == 'Book Chapter')
					{
						$icon = '<i class="fa  fa-file-text" style="font-size: 65px; padding: 0 20px;"></i>';
					}
					else if ($item->type == 'Conference')
					{
						$icon = '<i class="fa fa-institution" style="font-size: 65px; padding: 0 20px;"></i>';
					}
					else if ($item->type == 'Journal')
					{
						$icon = '<i class="fa  fa-file" style="font-size: 65px; padding: 0 20px;"></i>';
					}
					  	
					$publications .='	  	  <!-- result row -->
										  <div class="row">
										  	<div class="col-sm-2">
										  		'.$icon.'
										  	</div>
										  	<div class="col-sm-10">
										  		<h4><a href='.base_url().'user/profile?user='.$item->username.'>'.$item->pubTitle.'</a></h4>
										  		<h5>'.$item->catName.'</h5>
										  	</div>
									      </div>
									      <hr />
									      <!-- /.result row -->
									  ';	
				}
				
			}
			
			$publications .='	</div></div>';
		}
	}
	
	//creates the box if the filter is all or vacancies
	if($filter == "all" || $filter == "vacancies") {
		$this->db->select('*');
		$this->db->from('vacancies');
		$this->db->like('title', "$key");
		$this->db->or_like('description', "$key");
		$this->db->or_like('vCat', "$key");
		$query = $this->db->get();
		$data = $query->result();
		$count = $query->num_rows();
		 
		if($count>0) {
			$vacancies .='	<div id="vacanciesBox">
							  <div class="box-header with-border">
							      <h3 class="box-title">Vacancies</h3>
							  </div>
							  <div class="box-body">';
			
			foreach($data as $item)
			{
				$vacancies .='	  	  <!-- result row -->
									  <div class="row">
									  	<div class="col-sm-2">
									  		<i class="fa fa-suitcase" style="font-size: 65px; padding-left: 20px;"></i>
									  	</div>
									  	<div class="col-sm-10">
									  		<h4><a href="'.base_url().'applyJob?job='.$item->vID.'&RL='.$item->loginRequired.'">'.$item->title.'</a></h4>
									  		<h5>Deadline: '.$item->deadline.'</h5>
									  	</div>
								      </div>
								      <hr />
								      <!-- /.result row -->
								  ';
			}
			
			$vacancies .='	</div></div>';
		}
	}
	
	//creates the box if the filter is all or events
	if($filter == "all" || $filter == "events") {
		$this->db->select('*');
		$this->db->from('events');
		$this->db->like('eventName', "$key");
		$query = $this->db->get();
		$data = $query->result();
		$count = $query->num_rows(); 
		
		if($count>0) {
			$events .='	  <div id="eventsBox">
							  <div class="box-header with-border">
							      <h3 class="box-title">Events</h3>
							  </div>
							  <div class="box-body">';
			
			foreach($data as $item)
			{
				$this->db->from('event_media');
				$this->db->where('eventID = ', $item->eventID);
				$this->db->limit(1);
				$query2 = $this->db->get();
				$data2 = $query2->result();
							
				$link = "";
				foreach($data2 as $i)
				{	
					$link = $i->link;
				}
				
				$events .='	  	  <!-- result row -->
									  <div class="row">
									  	<div class="col-sm-2">
									  		<img class="img-responsive" src="'.$link.'" />
									  	</div>
									  	<div class="col-sm-10">
									  		<h4><a href="'.base_url().'eventpage?id='.$item->eventID.'">'.$item->eventName.'</a></h4>
									  		<h5>Date: '.$item->eventTime.'</h5>
									  	</div>
								      </div>
								      <hr />
								      <!-- /.result row -->
								  ';
			}
			
			$events .='	</div></div>';
		}
	}
	
	//creates the box if the filter is all or events
	if($filter == "all" || $filter == "news") {
		$this->db->select('*');
		$this->db->from('news');
		$this->db->like('headline', "$key");
		$this->db->or_like('subHeadline', "$key");
		$query = $this->db->get();
		$data = $query->result();
		$count = $query->num_rows(); 
		
		if($count>0) {
			$news .='	   <div id="newsBox">
							  <div class="box-header with-border">
							      <h3 class="box-title">News</h3>
							  </div>
							  <div class="box-body">';
			
			foreach($data as $item)
			{
				$news .='	  	  <!-- result row -->
									  <div class="row">
									  	<div class="col-sm-2">
									  		<i class="fa  fa-newspaper-o" style="font-size: 65px; padding: 0 20px;"></i>
									  	</div>
									  	<div class="col-sm-10">
									  		<h4><a href="'.base_url().'newsPage?id='.$item->newsID.'">'.$item->headline.'</a></h4>
									  		<h5>'.$item->subHeadline.'</h5>
									  	</div>
								      </div>
								      <hr />
								      <!-- /.result row -->
								  ';
			}
			
			$news .='	</div></div>';
		}
	}
}
else {
	$key = null;
}

?>

  <!-- Full Width Column -->
  <div class="content-wrapper">
    <div class="container">
      <!-- Content Header (Page header) -->
      <section class="content-header">
        <h1>
        </h1>
      </section>

      <!-- Main content -->
      <section class="content">
        <div class="container">
        	<div class="col-sm-4 col-xs-12 pull-right">
        		<div class="box" style="padding:20px">
		          <div class="box-header with-border">
			          <div class="pull-right box-tools">
			            <button type="button" class="btn btn-xs pull-right" data-widget="collapse" data-toggle="tooltip" title="Collapse" >
			              <i class="fa fa-minus"></i></button>
			          </div>
			          <!-- /. tools -->
			          <h3 class="box-title">Filter Results</h3>
				  </div>
		          <div class="box-body">
		          	<form>
		                 <div class="form-group">
	                 		  <div class="checkbox">
			                    <label>
			                      <input type="checkbox" name="optionsRadios" id="allCheck" value="all" onclick="toggle('all', this)" checked disabled="disabled">
			                      All
			                    </label>
			                  </div>
	
		                <?php

		                if ($people != '') {
		                 	echo '<div class="checkbox">
				                    <label>
				                      <input type="checkbox" name="optionsRadios" id="pplCheck" onclick="'; echo"toggle('#peopleBox', this)"; echo'" value="people" checked>
				                      People
				                    </label>
				                  </div>';	
		                }
						else {
							echo '<input type="hidden" id="pplCheck">';
						}
						if($projects != '') {
						 	echo '<div class="checkbox">
				                    <label>
				                      <input type="checkbox" name="optionsRadios" id="projCheck" onclick="';echo"toggle('#projectBox', this)"; echo'" value="projects" checked>
				                      Projects
				                    </label>
				                  </div>';
						}
						else {
							echo '<input type="hidden" id="projCheck">';
						}
						if($publications != '') {
						 	echo '<div class="checkbox">
				                    <label>
				                      <input type="checkbox" name="optionsRadios" id="pubCheck" onclick="';echo"toggle('#publicationBox', this)"; echo'" value="publications" checked>
				                      Publications
				                    </label>
				                  </div>';
						}
						else {
							echo '<input type="hidden" id="pubCheck">';
						}
						if($vacancies != '') {
						 	echo '<div class="checkbox">
				                    <label>
				                      <input type="checkbox" name="optionsRadios" id="vacanciesCheck" onclick="';echo"toggle('#vacanciesBox', this)"; echo'" value="vacancies" checked>
				                      Vacancies
				                    </label>
				                  </div>';
						}
						else {
							echo '<input type="hidden" id="vacanciesCheck">';
						}
						if($events != '') {
						 	echo '<div class="checkbox">
				                    <label>
				                      <input type="checkbox" name="optionsRadios" id="eventsCheck" onclick="';echo"toggle('#eventsBox', this)"; echo'" value="events" checked>
				                      Events
				                    </label>
				                  </div>';
						}
						else {
							echo '<input type="hidden" id="eventsCheck">';
						}
						if($news != '') {
						 	echo '<div class="checkbox">
				                    <label>
				                      <input type="checkbox" name="optionsRadios" id="newsCheck" onclick="';echo"toggle('#newsBox', this)"; echo'" value="news" checked>
				                      News
				                    </label>
				                  </div>';
						}
 						else {
							echo '<input type="hidden" id="newsCheck">';
						}
		                 
		                ?>		                  
		                </div>
		          	</form>
		          </div>
		        </div>
		        <!-- /.box -->        		
			</div>	
			
			<div class="col-sm-8 col-xs-12 pull-left">
        		<div class="box" style="padding:20px">
		          <div id="searchResults"></div>        
		          <?php 
		          
		          //if there are matching search results set results
		          if($people != '' || $publications != '' || $projects != '' || $vacancies != '' || $events != '' || $news != '') {
					  echo $people;
					  echo $projects;
					  echo $publications; 
					  echo $vacancies;
					  echo $events;
					  echo $news;	
		          }
				  //if there is no search term set text
				  else if ($key == null) {
					  echo "Please enter a search term!";				  			
				  }
				  //if there are no matching results set text
				  else {
					  echo "No matches!";				  			
				  }
		          
		          
		          ?>
		          
		        </div>
		        <!-- /.box -->
			</div>	
		</div>	
      </section>
      <!-- /.content -->
    </div>
    <!-- /.container -->
  </div>
  <!-- /.content-wrapper -->
  
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

<script>

function toggle(name, obj) {
    var $input = $(obj);
    
    //hides or shows the box
    if (name != 'all') {
    	if ($input.prop('checked')) 
    		$(name).show();
    	else 
    		$(name).hide();
    		
		//sets all to false since all boxes are no longer checked
		document.getElementById("allCheck").checked = false;
		//enables the all checkbox
		$('#allCheck').attr('disabled', false);
    }
    
    //shows all boxes if all is checked
    else {
    	$("#peopleBox").show();
    	$("#projectBox").show();
    	$("#publicationBox").show();
    	$("#vacanciesBox").show();
    	$("#eventsBox").show();
    	$("#newsBox").show();
    	
    	document.getElementById("pplCheck").checked = true;
    	document.getElementById("projCheck").checked = true;
    	document.getElementById("pubCheck").checked = true;
    	document.getElementById("vacanciesCheck").checked = true;
    	document.getElementById("eventsCheck").checked = true;
    	document.getElementById("newsCheck").checked = true;
    	
    	//disables all so that it cannot be unchecked
    	$('#allCheck').attr('disabled', true);
    }
    
    //sets message if all boxes are unchecked
    if(document.getElementById("allCheck").checked == false &&
    	document.getElementById("pplCheck").checked == false &&
    	document.getElementById("projCheck").checked == false &&
    	document.getElementById("pubCheck").checked == false &&
    	document.getElementById("vacanciesCheck").checked == false &&
    	document.getElementById("eventsCheck").checked == false &&
    	document.getElementById("newsCheck").checked == false) {
	
			$("#searchResults").html("Please select a filter option!");	
	}
	
	//clears message once something is checked
    if(document.getElementById("allCheck").checked == true ||
    	document.getElementById("pplCheck").checked == true ||
    	document.getElementById("projCheck").checked == true ||
    	document.getElementById("pubCheck").checked == true ||
    	document.getElementById("vacanciesCheck").checked == true ||
    	document.getElementById("eventsCheck").checked == true ||
    	document.getElementById("newsCheck").checked == true) {
	
			$("#searchResults").html("");	
	}
}
</script>