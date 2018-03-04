

  <!-- Full Width Column -->
  <div class="content-wrapper">

<link rel="stylesheet" href="<?php echo base_url() ?>dist/css/meet_team_css.css">

    <div class="container">
    <br>

     <div class="row">
     
     <div class="col">
     
     <div class="box box-success">
     <div class="box-header with-border">
	     <h1 style="color:#00a65a; text-align:center" >Infocomm Team</h1>  
     </div>   
     <div class="box-body">


<!-- ~~~=| team container start |=~~~ -->
<div class="container">
<h3 style="color:#00a65a" align="left">Lab Directors</h3>

		<?php
		
			$this->db->select('*');
			$this->db->from('users');
			$this->db->where('designation', 'Lab Director');
			$query = $this->db->get();
			$output = $query->result();
			//$output = $query->row();			
			foreach ($output as $o)
			{
				echo '
				<div class="column">
    <div class="card">
		<div class="center-cropped">
					          <img src="'.base_url().'resources/profile_image/'.$o->username.'.jpg" alt="User profile picture" style="width:100%">   
     
		</div>
      <div class="container">
        <h2>'.$o->fname.' '.$o->lname.' </h2>
        <p class="title">'.$o->designation.'</p>

      </div>
    </div>
  </div>
				';
			}
	?>		
  
</div> 
<!-- ~~~=| team container END |=~~~ -->

<?php
			//$query = $this->db->query("SELECT * FROM users u, positions p WHERE u.designation=p.designation AND p.designation != 'Lab Director' AND (u.usertype <> 'G' AND p.designation IS NOT NULL AND p.shownInOurteam <> -1 AND p.shownInOurteam <> 0) ORDER BY p.shownInOurteam ASC");
			
			$query = $this->db->query("SELECT * FROM positions WHERE designation != 'Lab Director' AND shownInOurteam <> -1 AND shownInOurteam <> 0 ORDER BY shownInOurteam ASC");
			
			$output = $query->result();
			//$output = $query->row();			
			foreach ($output as $o)
			{
			
				$position = $o->designation;
				
				$query = $this->db->query("SELECT * FROM users WHERE designation ='".$position."' AND usertype <> 'G'");
				$count = 0;
				
				$output2 = $query->result();
				foreach ($output2 as $o)
				{
					$count++;
				}
				
				if($count != 0){
					
					echo'
					<div class="container">
					<br>
					<h3 style="color:#00a65a" align="left">'.$position.'</h3>
					';
					
					foreach ($output2 as $o)
					{
						
						echo '
								<div class="column">
					<div class="card">
						<div class="center-cropped">
					          <img src="'.base_url().'resources/profile_image/'.$o->username.'.jpg" alt="User profile picture" style="width:100%">   
						</div>
					  <div class="container">
						<h2>'.$o->fname.' '.$o->lname.' </h2>
						<p class="title">'.$o->designation.'</p>
				
					  </div>
					</div>
				  </div>
				';
						
					}
					echo'
					</div>
					';	
				}
			}
			
			$query = $this->db->query("SELECT * FROM users u, positions p WHERE u.designation=p.designation AND (u.usertype <> 'G' AND u.designation IS NOT NULL AND p.shownInOurteam = 0)");
			
			$count1 = 0;
				
			$output3 = $query->result();
			foreach ($output3 as $o)
			{
					$count1++;
			}
			
			if($count1 != 0){
				
				echo'
					<div class="container">
					<br>
					<h3 style="color:#00a65a" align="left">And the rest of the Infocomm Crew</h3>
					';
					
					foreach ($output3 as $o)
					{
						
						echo '
								<div class="column">
					<div class="card">
						<div class="center-cropped">
					          <img src="'.base_url().'resources/profile_image/'.$o->username.'.jpg" alt="User profile picture" style="width:100%">   
						</div>
					  <div class="container">
						<h2>'.$o->fname.' '.$o->lname.' </h2>
						<p class="title">'.$o->designation.'</p>
				
					  </div>
					</div>
				  </div>
				';
					}
					
					echo'
					</div>
					';		
					
			}
			
		?>

     </div>
     </div>
     
     </div>
     
     </div>
     
     </div>

  </div>
  <!-- /.content-wrapper -->