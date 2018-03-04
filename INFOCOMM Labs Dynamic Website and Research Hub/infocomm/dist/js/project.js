// $(function () {
//    $("#example1").DataTable();
//    $('#example2').DataTable({
//      "paging": true,
//      "lengthChange": false,
//      "searching": true,
//      "ordering": true,
//      "info": true,
//      "autoWidth": false
//    });
//  });
  
$(document).ready(function() {
	
	var currentuserid = $('#currentuserID').val();
	var currentprojid = $('#currentprojID').val();
	
	/////////////////////////////
	//functions for members tab//
	/////////////////////////////
	$('#searchmember').on('keyup', function(){
		var ss = $(this).val()
		//alert(ss)
		if(ss !== ""){
			$.post("projectprofile/searchmember", {ss:ss, currentprojid:currentprojid}, function(data){
				$('#myResult').html(data)
			})
		}else{
			$('#myResult').html('')
		}
	})
	
	$(document).on('click', '#searchSelect', function(){
		var parent = $(this).closest('.box-header');
		var selected = $(this, parent).html();
		var un =  $(this, parent).data('uname');
		var uid =  $(this, parent).data('id');
		$('#searchmember').val(un);
		$('#selectedUID').val(uid);
		$('#myResult').html('');
	})
	
	$(document).on('click','#addmemberBtn', function(){
	
		var selecteduser = $('#selectedUID').val();
	
					$.ajax({
					type:'POST',
					url:"projectprofile/addmember",
					data:{'userid':selecteduser,
						  'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  }
				    });   
	  
  });
  
  	$(document).on('click','#removememberbtn', function(){
	
		var selecteduser = $(this).data("uid");
	
					$.ajax({
					type:'POST',
					url:"projectprofile/removemember",
					data:{'userid':selecteduser,
						  'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  }
				    });   
	  
  });	  
	
		//////////////////////////////////
		//functions for publications tab//
		//////////////////////////////////
	
		$('#searchpub').on('keyup', function(){
		var ss = $(this).val()
		//alert(ss)
		if(ss !== ""){
			$.post("projectprofile/searchpubs", {ss:ss, pp:currentprojid}, function(data){
				$('#myResultpub').html(data)
			})
		}else{
			$('#myResultpub').html('')
		}
	})
	
	$(document).on('click', '#searchSelectpub', function(){
		var parent = $(this).closest('.box-header');
		var selected = $(this, parent).html();
		var un =  $(this, parent).data('uname');
		var uid =  $(this, parent).data('id');
		$('#searchpub').val(un);
		$('#selectedPID').val(uid);
		$('#myResultpub').html('');
	})
	
	$(document).on('click','#addpubBtn', function(){
	
		var selectedpub = $('#selectedPID').val();
	
					$.ajax({
					type:'POST',
					url:"projectprofile/addpub",
					data:{'pubid':selectedpub,
						  'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  }
				    });   
	  
  });
  
  	$(document).on('click','#removepubbtn', function(){
	
		var selectedpub = $(this).data("pid");
	
					$.ajax({
					type:'POST',
					url:"projectprofile/removepub",
					data:{'pubid':selectedpub,
						  'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  }
				    });   
	  
  });
	
	
		//////////////////////////////////
		//functions for events tab      //
		//////////////////////////////////	

		$('#searchev').on('keyup', function(){
		var ss = $(this).val()
		//alert(ss)
		if(ss !== ""){
			$.post("projectprofile/searchev", {ss:ss, pp:currentprojid}, function(data){
				$('#myResultev').html(data)
			})
		}else{
			$('#myResultev').html('')
		}
	})

	$(document).on('click', '#searchSelectev', function(){
		var parent = $(this).closest('.box-header');
		var selected = $(this, parent).html();
		var en =  $(this, parent).data('ename');
		var eid =  $(this, parent).data('eid');
		$('#searchev').val(en);
		$('#selectedEID').val(eid);
		$('#myResultev').html('');
	})	
	
	$(document).on('click','#addevBtn', function(){
	
		var selectedev = $('#selectedEID').val();
	
					$.ajax({
					type:'POST',
					url:"projectprofile/addev",
					data:{'eid':selectedev,
						  'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  }
				    });   
	  
  });
	
  	$(document).on('click','#removeeventbtn', function(){
	
		var selectedev = $(this).data("eid");
	
					$.ajax({
					type:'POST',
					url:"projectprofile/removeev",
					data:{'eid':selectedev,
						  'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  }
				    });   
	  
  });	
	

		//////////////////////////////////
		//functions for funders tab	    //
		//////////////////////////////////	

		$('#searchfun').on('keyup', function(){
			
		var ss = $(this).val()
		//alert(ss)
		if(ss !== ""){
			$.post("projectprofile/searchfun", {ss:ss, pp:currentprojid}, function(data){
				$('#myResultfun').html(data)
			})
		}else{
			$('#myResultfun').html('')
		}
	})

	$(document).on('click', '#searchSelectfun', function(){
		var parent = $(this).closest('.box-header');
		var selected = $(this, parent).html();
		var en =  $(this, parent).data('fname');
		var eid =  $(this, parent).data('fid');
		$('#searchfun').val(en);
		$('#selectedFID').val(eid);
		$('#myResultfun').html('');
	})	
	
	$(document).on('click','#addfunBtn', function(){
	
		var selectedfun = $('#selectedFID').val();
	
					$.ajax({
					type:'POST',
					url:"projectprofile/addfun",
					data:{'fid':selectedfun,
						  'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  }
				    });   
	  
  });
	
  	$(document).on('click','#removefunbtn', function(){
	
		var selectedfun = $(this).data("fid");
	
					$.ajax({
					type:'POST',
					url:"projectprofile/removefun",
					data:{'fid':selectedfun,
						  'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  }
				    });   
	  
  });	

	$(document).on('click','#createfunBtn', function(){
	
		var selectedfun = $('#createfun').val();
					$.ajax({
					type:'POST',
					url:"projectprofile/createfun",
					data:{'fname':selectedfun,
							'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								alert(output);
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  },
  					error: function(XMLHttpRequest, textStatus, errorThrown) {
     					alert('invalid funder (funder may already exist)');
  					}
				    });   
	  
  });

  //upload image
  
//  	$(document).on('click','#editfunderimage', function(){
//			//$('#EditfunderimageModal').modal('show')
////			//gets the data
//			var fundername = $(this).data("id3");
////			
////			//passes the value to the modal
//			$("#imageID").val('hello');
////			//document.getElementById("imageID").value = "1";
//			$('.modal-title').html(fundername);
//			$('#EditfunderimageModal').modal('show')
//			//$('.modal-body').data("fn",fundername);
//
//			//$(inputid).on('change', function(){
//				//$('#imageID').val($(this).data("id3"))
//				//$('#img').trigger('click');
//
//			
//	  
//  });

$('#outsidefunderform button').each( function() {
    $(this).click( function() {
	var fn = $(this).data('id3')
	$('#funderimageID').val(fn)
	var fp = $(this).data('id4')
	$('#funderimagepath').val(fp)
	$('#funderimg').trigger('click');	
    });
});

//$('#clicker').on('click', function(){
//	var fn = $(this).data('id3')
//	$('#funderimageID').val(fn)
//	$('#funderimg').trigger('click');
//})
  
$('#outsidefunderform').on('change', function(){
	var file = 	$('#funderimg')
	if(file == null){
		alert('no file it seems')
	}
	else{
	$.ajax({
				
				url: "projectprofile/uploadFunderImage",
				type: "POST",
				data: new FormData(this),
				contentType: false,
				cache: false,
				processData: false,
				success: function(result, status){
					//alert(result)
					if(result == "Success")
					{
						alert("Added image Successfully! (cache may be need to cleared to reflect changes)");
						window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
					}
					else
					{
						window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
						alert(result);
					}
				}					
			});
	}

})
  
//	$(document).on('submit', "#uploadfunderForm",function(e) {
//	e.preventDefault();	
//		var test = $('#imageID').val();		
//	var projid = currentprojid;
//	alert(test)
//			//var form = $('uploadfunderForm')[0]
//			//var formdata = new FormData(form)			
//			$.ajax({
//				
//				url: "projectprofile/uploadFunderImage",
//				type: "POST",
//				data: new FormData(this),
//				contentType: false,
//				cache: false,
//				processData: false,
//				success: function(result, status){
//					alert(result)
//					if(result == "Success")
//					{
//						//alert("Added image Successfully! (cache may be need to cleared to reflect changes)");
//						window.location = $('#baseURL').val()+'user/projectprofile?projid='+projid;
//					}
//					else
//					{
//						window.location = $('#baseURL').val()+'user/projectprofile?projid='+projid;
//						//alert(result);
//					}
//				}					
//			});
//			
//		});  		 



		///////////////////////////////////////////
		//functions for collaborators tab	    //
		//////////////////////////////////////////	

		$('#searchcol').on('keyup', function(){
			
		var ss = $(this).val()
		//alert(ss)
		if(ss !== ""){
			$.post("projectprofile/searchcol", {ss:ss, pp:currentprojid}, function(data){
				$('#myResultcol').html(data)
			})
		}else{
			$('#myResultcol').html('')
		}
	})

	$(document).on('click', '#searchSelectcol', function(){
		var parent = $(this).closest('.box-header');
		var selected = $(this, parent).html();
		var cn =  $(this, parent).data('cname');
		var cid =  $(this, parent).data('cid');
		$('#searchcol').val(cn);
		$('#selectedCID').val(cid);
		$('#myResultcol').html('');
	})	
	
	$(document).on('click','#addcolBtn', function(){
	
		var selectedcol = $('#selectedCID').val();
	
					$.ajax({
					type:'POST',
					url:"projectprofile/addcol",
					data:{'cid':selectedcol,
						  'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  }
				    });   
	  
  });
	
  	$(document).on('click','#removecolbtn', function(){
	
		var selectedcol = $(this).data("cid");
	
					$.ajax({
					type:'POST',
					url:"projectprofile/removecol",
					data:{'cid':selectedcol,
						  'projid':currentprojid},

					success: function(output){
							if(output == 'done'){
								//$('.box-body').load(document.URL+'.box-body')
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							else{
								$('.box-body').load(document.URL+'.box-body')
								window.location = $('#baseURL').val()+'user/projectprofile?projid='+currentprojid;
							}
							
						  }
				    });   
	  
  });
	
	
		
	
});