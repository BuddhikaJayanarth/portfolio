<?php ;
$eventID = 0;

if(isset($_GET['id']))
{
	$eventID = $_GET['id'];
}

//query to get the events
$this->db->where('eventID =', $eventID);
$this->db->from("events");
$query2 = $this->db->get();
$eventList = $query2->result();

$events = '';

//creates the upcoming events section
foreach($eventList as $event)
{
	$this->db->where('eventID', $event->eventID);
	$this->db->from("event_media");
	$query = $this->db->get();
	$mediaList = $query->result();
	$count = 0;
	$imgList = "";
	$liList = "";
	
	foreach ($mediaList as $image) {
		if($count == 0)
		{
			$liList .= '<li data-target="#carousel" data-slide-to="'.$count.'" class="active"></li>';
			$imgList .= ' <div class="item active">
					        <img src="'.$img = $image->link.'">
					      </div>';
		}
		else
		{
			$liList .= '<li data-target="#carousel" data-slide-to="'.$count.'" class=""></li>';
			$imgList .= ' <div class="item">
					        <img src="'.$img = $image->link.'">
					      </div>';
		}
		
		$count++;
		
	}
	
	$start_time = date('g:iA', strtotime($event->eventTime));
	$end_time = date("g:iA", strtotime('+'.$event->duration.' hour',strtotime($event->eventTime)));
	$date = date('D, d M Y', strtotime($event->date));
	
	$events .= '<div class="col-md-6 pull-right">
		        	<div id="carousel" class="carousel slide" data-ride="carousel">
		                <ol class="carousel-indicators">
		                  '.$liList.'
		                </ol>
		                <div class="carousel-inner">
		                  '.$imgList.'
		                </div>
		                <a class="left carousel-control" href="#carouse" data-slide="prev">
		                  <span class="fa fa-angle-left"></span>
		                </a>
		                <a class="right carousel-control" href="#carousel" data-slide="next">
		                  <span class="fa fa-angle-right"></span>
		                </a>
		              </div>
		        </div>		
		        <div class="col-md-6" style="font-size: 18px;">
		        	<h2 style="color:#00a65a;">'.$event->eventName.'</h2>
		            <p><span style="font-style:italic; font-weight:600;">When:</span> '.$date.'</p>
		            <p style="padding-left:3em">'.$start_time.' - '.$end_time.'</p>
		            <p><span style="font-style:italic; font-weight:600;">Where:</span> '.$event->location.'</p>
		            <p><span style="font-style:italic; font-weight:600;">What:</span> '.$event->description.'</p>
		        </div>';

}
?>
  <!-- Full Width Column -->
  <div class="content-wrapper">
    
    <div style="min-height:600px; height:auto; background-attachment: fixed;
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover; background-image: url('<?php echo base_url(); ?>resources/event-banner.jpg')")>
		
    	<div class="container">	
      <!-- Main content -->
      <section class="content" style="padding-top:10%; padding-bottom:10%; color: black; text-align: left">
	     <div class="row">
	     	<div class="col-md-1"></div>
		     <div class="col-md-10">
			     <div class="box">
				     <div class="box-body" style="padding: 7%;">
		              	<?php echo $events; ?>
		            </div>
			     </div>
		     </div>
	     </div>	     
      </section>
      <!-- /.content -->
    </div>
    <!-- /.container -->
	</div>
	
    
  </div>
  <!-- /.content-wrapper -->