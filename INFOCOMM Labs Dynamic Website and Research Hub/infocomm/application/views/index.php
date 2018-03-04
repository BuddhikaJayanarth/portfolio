<?php
//query to get the projects 
$this->db->limit(4);
$this->db->order_by('dateCreated', 'DESC');
$query = $this->db->get('user_projects');
$projectList = $query->result();

//query to get the events
$this->db->limit(5);
$this->db->order_by('date', 'DESC');
$query2 = $this->db->get('events');
$eventList = $query2->result();

$projects = '';
$events = '';
$count = 0;

//creates the project section
foreach($projectList as $project)
{
	$count++;
	if ($count == 1 || $count == 3)
			$projects .= '<tr>';
	$projects .= makeProject($project, 'resources/projects/', 'projectprofile?projid=');
	if ($count == 2 || $count == 4)
			$projects .= '</tr>';
}

//creates the events section
foreach($eventList as $e)
{
	$img = " ";
	
	$this->db->where('eventID', $e->eventID);
	$this->db->from("event_media");
	$this->db->limit(1);
	$query = $this->db->get();
	$mediaList = $query->result();
	
	foreach ($mediaList as $image) {
		$img = $image->link;
	}
	
	$events .= '<tr>';
	$events .= makeEvent($e, 'eventpage?id=', $img);
	$events .= '</tr>';
}

//Makes a project cell
function makeProject($proj, $imgPath, $link) {
	return '<td><a href="'.$link.$proj->projectID.'">
		<h4 style="color:#00a65a;">'.$proj->projectTitle.'</h4>
		<p class="text-muted">
        	<img class="img-responsive pull-left" style="margin-right:8px;" src="'. base_url() .$imgPath.$proj->projectID.'.jpg" width="80">
        
            '.truncate($proj->description, 150).'
        </p>		
	</a></td>';
}

//Makes an event cell
function makeEvent($event, $Elink, $img) {
	$start_time = date('g:iA', strtotime($event->eventTime));
	$end_time = date("g:iA", strtotime('+'.$event->duration.' hour',strtotime($event->eventTime)));
	$date = date('D, d M Y', strtotime($event->date));
	
	return '<td><a href="'.$Elink.$event->eventID.'">
		<a href="'.$Elink.$event->eventID.'"><h4 style="color:#00a65a;">'.$event->eventName.'</h4></a>
		<div class="col-xs-6 pull-left" style="margin:0; padding:0;">
        	<img class="img-responsive pull-left" src="'.$img.'" width="80">
        </div>		
        <div class="col-xs-6 text-muted pull-right" style="margin:0; padding:0; font-size:12px;">
            <p>'.$date.'</p>
            <p>'.$start_time.'-'.$end_time.'</p>
            <p>'.$event->location.'</p>
        </div>
	</a></td>';
}

/* Function Source : https://stackoverflow.com/questions/3161816/get-first-n-characters-of-a-string
 * Access on: 19th October 2017
 */
function truncate($string,$length=100,$append=" &hellip;") {
  $string = trim($string);

  if(strlen($string) > $length) {
    $string = wordwrap($string, $length);
    $string = explode("\n", $string, 2);
    $string = $string[0] . $append;
  }

  return $string;
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
        <div class="row">
			
            <div class="col-sm-9">
	            <div class="row">
		            <div class="box box-success">
				            <div class="box-body">
				              <div id="carousel" class="carousel slide" data-ride="carousel">
				                <ol class="carousel-indicators">
				                  <li data-target="#carousel" data-slide-to="0" class="active"></li>
				                  <li data-target="#carousel" data-slide-to="1" class=""></li>
				                  <li data-target="#carousel" data-slide-to="2" class=""></li>
				                </ol>
				                <div class="carousel-inner">
				                  <div class="item active">
				                    <a title="View Our Projects" href="<?php echo base_url();?>index.php/projects"><img src="<?php echo base_url() ?>dist/img/index/project.png" alt="Projects"></a>
				                  </div>
				                  <div class="item">
				                    <a title="View Our Publications" href="<?php echo base_url();?>index.php/viewPublications"><img src="<?php echo base_url() ?>dist/img/index/research.png" alt="Publications"></a>
				                  </div>
				                  <div class="item">
				                    <a title="Meet Our Team" href="<?php echo base_url();?>index.php/ourteam"><img src="<?php echo base_url() ?>dist/img/index/team.png" alt="Our Team"></a>
				                  </div>
				                </div>
				                <a class="left carousel-control" href="#carouse" data-slide="prev">
				                  <span class="fa fa-angle-left"></span>
				                </a>
				                <a class="right carousel-control" href="#carousel" data-slide="next">
				                  <span class="fa fa-angle-right"></span>
				                </a>
				              </div>
				           </div>
		            </div>
	            </div>
	            
	            
	              
     
		     <div class="row">
			     <div class="box box-success">
				     <div class="box-header">
				     	<h2 class="text-center text-bold" style="color:#00a65a; text-decoration: underline">LATEST PROJECTS</h2>     
				     	<div class="box-body">
				     
				     		<table class="table table-hover">
				            <tbody>
				            	<?php echo $projects; ?>			            
				            </tbody>
				            </table>
				    	 </div>
				     </div>
			     </div>
		     </div>
            </div>
            
            <div class="col-sm-3 col-xs-12">
            <div class="box box-success">
            <div class="box-header">
            <h4 class="text-center text-bold" style="color:#00a65a;">UPCOMING EVENTS</h4>
				<div class="box-body">
		            <table class="table table-hover">
			            <tbody>
			            
			            	<?php echo $events ?>
				        
			            </tbody>
		            </table>
		            <br />
		            <a href="<?php echo base_url();?>index.php/events"><button type="button" class="btn btn-block btn-success btn-xs">See more Events</button></a>
	            </div>
			</div>
            </div>
            </div>
          

      </div>
      <!-- end of row -->
     
   
        
        <!-- /.box -->
      </section>
      <!-- /.content -->
    </div>
    <!-- /.container -->
  </div>
  <!-- /.content-wrapper -->