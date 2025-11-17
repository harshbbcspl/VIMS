let dataSet = [
    [ "Tiger Nixon", "System Architect", "Edinburgh", "5421", "2011/04/25", "$320,800" ],
    [ "Garrett Winters", "Accountant", "Tokyo", "8422", "2011/07/25", "$170,750" ],
    [ "Ashton Cox", "Junior Technical Author", "San Francisco", "1562", "2009/01/12", "$86,000" ],
    [ "Cedric Kelly", "Senior Javascript Developer", "Edinburgh", "6224", "2012/03/29", "$433,060" ],
    [ "Airi Satou", "Accountant", "Tokyo", "5407", "2008/11/28", "$162,700" ],
    [ "Brielle Williamson", "Integration Specialist", "New York", "4804", "2012/12/02", "$372,000" ],
    [ "Herrod Chandler", "Sales Assistant", "San Francisco", "9608", "2012/08/06", "$137,500" ],
    [ "Rhona Davidson", "Integration Specialist", "Tokyo", "6200", "2010/10/14", "$327,900" ],
    [ "Colleen Hurst", "Javascript Developer", "San Francisco", "2360", "2009/09/15", "$205,500" ],
    [ "Sonya Frost", "Software Engineer", "Edinburgh", "1667", "2008/12/13", "$103,600" ],
    [ "Jena Gaines", "Office Manager", "London", "3814", "2008/12/19", "$90,560" ],
    [ "Quinn Flynn", "Support Lead", "Edinburgh", "9497", "2013/03/03", "$342,000" ],
    [ "Charde Marshall", "Regional Director", "San Francisco", "6741", "2008/10/16", "$470,600" ],
    [ "Haley Kennedy", "Senior Marketing Designer", "London", "3597", "2012/12/18", "$313,500" ],
    [ "Tatyana Fitzpatrick", "Regional Director", "London", "1965", "2010/03/17", "$385,750" ],
    [ "Michael Silva", "Marketing Designer", "London", "1581", "2012/11/27", "$198,500" ],
    [ "Paul Byrd", "Chief Financial Officer (CFO)", "New York", "3059", "2010/06/09", "$725,000" ],
    [ "Gloria Little", "Systems Administrator", "New York", "1721", "2009/04/10", "$237,500" ],
    [ "Bradley Greer", "Software Engineer", "London", "2558", "2012/10/13", "$132,000" ],
    [ "Dai Rios", "Personnel Lead", "Edinburgh", "2290", "2012/09/26", "$217,500" ],
    [ "Jenette Caldwell", "Development Lead", "New York", "1937", "2011/09/03", "$345,000" ],
    [ "Yuri Berry", "Chief Marketing Officer (CMO)", "New York", "6154", "2009/06/25", "$675,000" ],
    [ "Caesar Vance", "Pre-Sales Support", "New York", "8330", "2011/12/12", "$106,450" ],
    [ "Doris Wilder", "Sales Assistant", "Sidney", "3023", "2010/09/20", "$85,600" ],
    [ "Angelica Ramos", "Chief Executive Officer (CEO)", "London", "5797", "2009/10/09", "$1,200,000" ],
    [ "Gavin Joyce", "Developer", "Edinburgh", "8822", "2010/12/22", "$92,575" ],
    [ "Jennifer Chang", "Regional Director", "Singapore", "9239", "2010/11/14", "$357,650" ],
    [ "Brenden Wagner", "Software Engineer", "San Francisco", "1314", "2011/06/07", "$206,850" ],
    [ "Fiona Green", "Chief Operating Officer (COO)", "San Francisco", "2947", "2010/03/11", "$850,000" ],
    [ "Shou Itou", "Regional Marketing", "Tokyo", "8899", "2011/08/14", "$163,000" ],
    [ "Michelle House", "Integration Specialist", "Sidney", "2769", "2011/06/02", "$95,400" ],
    [ "Suki Burks", "Developer", "London", "6832", "2009/10/22", "$114,500" ],
    [ "Prescott Bartlett", "Technical Author", "London", "3606", "2011/05/07", "$145,000" ],
    [ "Gavin Cortez", "Team Leader", "San Francisco", "2860", "2008/10/26", "$235,500" ],
    [ "Martena Mccray", "Post-Sales support", "Edinburgh", "8240", "2011/03/09", "$324,050" ],
    [ "Unity Butler", "Marketing Designer", "San Francisco", "5384", "2009/12/09", "$85,675" ]
];




(function($) {
     "use strict"
	 
	 
  
	// Styling js start
	if ($("#md1").hasClass("bolds1")) {
		$('#base-style').DataTable({
			"bJQueryUI": true,
			'dom': '<"top"flB>rtip',
			language: {
				paginate: {
					next: '<i class="fa-solid fa-angle-right"></i>',
					previous: '<i class="fa-solid fa-angle-left"></i>'
				}
			},
			buttons: [
				{
					extend: 'excelHtml5',
					text: '<span class="ti ti-file-type-xls" style="font-size:1.75em;"></span>',
					footer: true,
					className: 'btn border-0',
					exportOptions: {
						columns: ':not(:first-child)',
					},
					customizeData: function (data) {
						debugger
						var table = $('#base-style').DataTable();
						var rows = table.rows({ search: 'applied' }).nodes().to$();

						for (var i = 0; i < rows.length; i++) {
							var rowData = data.body[i];
							var checkboxElement = $(rows[i]).find('input[type="checkbox"]');
							var toggleValues = [];

							checkboxElement.each(function () {
								var isChecked = $(this).prop('checked');
								toggleValues.push(isChecked.toString());
							});

							for (var j = 0; j < toggleValues.length; j++) {
								var columnIndex = $(checkboxElement[j]).closest('td').index()-1;
								rowData[columnIndex] = toggleValues[j];
							}
						}
					}
				}
			],
			columnDefs: [
				{ orderable: false, targets: 0 }
			],
			aaSorting: [[0]],
			initComplete: function () {
				var filterWrapper = $('.dataTables_filter');
				var buttonsContainer = $('<div class="buttons-container float-end d-flex"></div>').insertAfter(filterWrapper);
				$('.buttons-container').append($('.dt-buttons'));
			}
		});

	}
	else {
		$('#base-style').DataTable({
			"bJQueryUI": true,
			'dom': '<"top"flB>rtip',

			language: {
				paginate: {
					next: '<i class="fa-solid fa-angle-right"></i>',
					previous: '<i class="fa-solid fa-angle-left"></i>'
				}
			},
			buttons: [
				{
					extend: 'excelHtml5',
					text: '<span class="ti ti-file-type-xls" style="font-size:1.75em;"></span>',
					footer: true,
					className: 'btn border-0',
					customizeData: function (data) {
						var table = $('#base-style').DataTable();
						var rows = table.rows({ search: 'applied' }).nodes().to$();

						for (var i = 0; i < rows.length; i++) {
							var rowData = data.body[i];
							var checkboxElement = $(rows[i]).find('input[type="checkbox"]');
							var toggleValues = [];

							checkboxElement.each(function () {
								var isChecked = $(this).prop('checked');
								toggleValues.push(isChecked.toString());
							});

							for (var j = 0; j < toggleValues.length; j++) {
								var columnIndex = $(checkboxElement[j]).closest('td').index();
								rowData[columnIndex] = toggleValues[j];
							}
						}
					}
				}
			],
			columnDefs: [
				{ orderable: false, targets: 0 }
			],
			aaSorting: [[0]],
			initComplete: function () {
				var filterWrapper = $('.dataTables_filter');
				var buttonsContainer = $('<div class="buttons-container float-end d-flex"></div>').insertAfter(filterWrapper);
				$('.buttons-container').append($('.dt-buttons'));
			}
		});
    }
	$('#example tbody').on('click', 'tr', function () {
		var data = table.row( this ).data();
	});
   
    // Datatable JS Start
    if ($('.datatable').length > 0) {
        $('.datatable').DataTable({
            "bJQueryUI": true,
            'dom': '<"top"flB>rtip',
            language: {
                paginate: {
                    next: '<i class="fa fa-angle-right"></i>',
                    previous: '<i class="fa fa-angle-left"></i>'
                }
            },
            buttons: [
                {
                    extend: 'excelHtml5',
                    text: '<span class="ti ti-file-type-xls" style="font-size:1.75em;"></span>',
                    footer: true,
                    className: 'btn border-0',
                    //customizeData: function (data) {
                    //    var table = $('.datatable').DataTable();
                    //    var rows = table.rows({ search: 'applied' }).nodes().to$();

                    //    for (var i = 0; i < rows.length; i++) {
                    //        var rowData = data.body[i];
                    //        var checkboxElement = $(rows[i]).find('input[type="checkbox"]');
                    //        var toggleValues = [];

                    //        checkboxElement.each(function () {
                    //            var isChecked = $(this).prop('checked');
                    //            toggleValues.push(isChecked.toString());
                    //        });

                    //        for (var j = 0; j < toggleValues.length; j++) {
                    //            var columnIndex = $(checkboxElement[j]).closest('td').index()-1;
                    //            rowData[columnIndex] = toggleValues[j];
                    //        }
                    //    }
                    //}
                    customizeData: function (data) {
                        var table = $('.datatable').DataTable();
                        var rows = table.rows({ search: 'applied' }).nodes().to$();

                        var actionIndex = -1;

                        for (var i = 0; i < data.header.length; i++) {
                            if (data.header[i] === 'Action') {
                                actionIndex = i;
                                break;
                            }
                        }

                        if (actionIndex !== -1) {
                            data.header.splice(actionIndex, 1);
                            data.body.forEach(function (row) {
                                row.splice(actionIndex, 1);
                            });
                        }

                        var isActiveIndex = -1; // Store the index of the "IsActive" column header

                        for (var i = 0; i < data.header.length; i++) {
                            if (data.header[i] === 'IsActive' || data.header[i] === 'Active'  || data.header[i] === 'Status') {
                                isActiveIndex = i;
                                break;
                            }
                        }

                        if (isActiveIndex !== -1) {
                            for (var i = 0; i < rows.length; i++) {
                                var rowData = data.body[i];
                                var checkboxElement = $(rows[i]).find('input[type="checkbox"]');
                                var isActiveValue = checkboxElement.prop('checked') ? 'Active' : 'NotActive';
                                rowData[isActiveIndex] = isActiveValue; // Set "IsActive" value to the corresponding column
                            }
                        }
                    }
                }
            ],
            columnDefs: [
                { orderable: false, targets: [0] }, // Add other column indexes to remove
            ],
            aaSorting: [[0]],
            initComplete: function () {
                var filterWrapper = $('.dataTables_filter');
                var buttonsContainer = $('<div class="buttons-container float-end d-flex"></div>').insertAfter(filterWrapper);
                $('.buttons-container').append($('.dt-buttons'));
            }
        });
        var divElement = $('<div>').addClass('table-responsive');

        var tableElement = $('.datatable');

        tableElement.wrap(divElement);
    }
    if ($('.datatableWithoutBtn').length > 0) {
        $('.datatableWithoutBtn').DataTable({
            "bJQueryUI": true,
            'dom': '<"top"fl>rtip',
            language: {
                paginate: {
                    next: '<i class="fa fa-angle-right"></i>',
                    previous: '<i class="fa fa-angle-left"></i>'
                }
            },
            columnDefs: [
                { orderable: false, targets: [0] }, // Add other column indexes to remove
            ],
            aaSorting: [[0]],
            initComplete: function () {
                var filterWrapper = $('.dataTables_filter');
            }
        });
        var divElement = $('<div>').addClass('table-responsive');

        var tableElement = $('.datatableWithoutBtn');

        tableElement.wrap(divElement);
    }
    if ($('#datatableTxt').length > 0) {
        $('#datatableTxt').DataTable({
            "bJQueryUI": true,
            'dom': '<"top"flB>rtip',
            language: {
                paginate: {
                    next: '<i class="fa fa-angle-right"></i>',
                    previous: '<i class="fa fa-angle-left"></i>'
                }
            },
            buttons: [
                {
                    extend: 'excelHtml5',
                    text: '<span class="ti ti-file-type-xls" style="font-size:1.75em;"></span>',
                    footer: true,
                    className: 'btn border-0',
                    customizeData: function (data) {
                        var table = $('#datatableTxt').DataTable();
                        var rows = table.rows({ search: 'applied' }).nodes().to$();

                        var actionIndex = -1;

                        for (var i = 0; i < data.header.length; i++) {
                            if (data.header[i] === 'Action') {
                                actionIndex = i;
                                break;
                            }
                        }

                        if (actionIndex !== -1) {
                            data.header.splice(actionIndex, 1);
                            data.body.forEach(function (row) {
                                row.splice(actionIndex, 1);
                            });
                        }

                        var isActiveIndex = -1; // Store the index of the "IsActive" column header

                        for (var i = 0; i < data.header.length; i++) {
                            if (data.header[i] === 'IsActive' || data.header[i] === 'Status') {
                                isActiveIndex = i;
                                break;
                            }
                        }

                        if (isActiveIndex !== -1) {
                            for (var i = 0; i < rows.length; i++) {
                                var rowData = data.body[i];
                                var checkboxElement = $(rows[i]).find('input[type="checkbox"]');
                                var isActiveValue = checkboxElement.prop('checked') ? 'Yes' : 'No';
                                rowData[isActiveIndex] = isActiveValue; // Set "IsActive" value to the corresponding column
                            }
                        }
                    }
                },
                {
                    text: '<span class="ti ti-file-type-txt" style="font-size:1.75em;"></span>',
                    footer: true,
                    className: 'btn border-0',
                    action: function (e, dt, button, config) {
                        var csv = dt.buttons.exportData({ format: { body: function (data, row, column, node) { return data; } } });
                        var txtContent = '';

                        for (var i = 0; i < csv.body.length; i++) {
                            txtContent += csv.body[i].join('\t') + '\n';
                        }
                        var blob = new Blob([txtContent], { type: 'text/plain;charset=utf-8' });
                        var link = document.createElement('a');
                        link.href = window.URL.createObjectURL(blob);
                        link.download = getExportFileName()+'.txt';

                        document.body.appendChild(link);
                        link.click();
                        document.body.removeChild(link);
                    }
                }
            ],
            columnDefs: [
                { orderable: false, targets: [0] }, // Add other column indexes to remove
            ],
            aaSorting: [[0]],
            initComplete: function () {
                var filterWrapper = $('.dataTables_filter');
                var buttonsContainer = $('<div class="buttons-container float-end d-flex"></div>').insertAfter(filterWrapper);
                $('.buttons-container').append($('.dt-buttons'));
            }
        });
        var divElement = $('<div>').addClass('table-responsive');

        var tableElement = $('#datatableTxt');

        tableElement.wrap(divElement);
    }


    if ($('.FixedHeaderDatatable').length > 0) {
        $('.FixedHeaderDatatable').DataTable({
            "bJQueryUI": true,

            "scrollY": true,
            "scrollX": false,
            "dom": '<"top"if><"tabs"t>',
            "bPaginate": false,
            "bLengthChange": false,
            columnDefs: [
                { orderable: false, targets: [0] },
            ],
            aaSorting: [[0]],
            initComplete: function () {
                var filterWrapper = $('.dataTables_filter');
                var buttonsContainer = $('<div class="buttons-container float-end d-flex"></div>').insertAfter(filterWrapper);
                $('.buttons-container').append($('.dataTables_filter'));
            }
        });
        var divElement = $('<div>').addClass('table-responsive');

        var tableElement = $('.FixedHeaderDatatable');

        tableElement.wrap(divElement);
    }
    // Datatable JS End
})(jQuery);
