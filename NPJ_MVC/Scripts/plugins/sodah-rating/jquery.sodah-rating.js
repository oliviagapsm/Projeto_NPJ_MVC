/*
 * jQuery Sodah Rating Plugin V1.16.05.03
 *
 * Copyright (C) SODAH | JOERG KRUEGER
 * http://www.sodah.de | http://rating.sodah.de
 * 
 */
(function (root, factory) {
	if (typeof define === 'function' && define.amd) {
		define(['jquery'], factory); 
	} else {
		if(root.jQuery) { 
			factory(root.jQuery);
		} else { 
			factory(root.Zepto);
		}
	}
}(this, function ($, undefined) {
	$.fn.sodahrating = function( options ) {
		var name = "sodahrating";
		var isMethodCall = typeof options === "string",
			args = Array.prototype.slice.call( arguments, 1 ),
			returnValue = this;

		options = !isMethodCall && args.length ?
			$.extend.apply( null, [ true, options ].concat(args) ) :
			options;

		if ( isMethodCall && options.charAt( 0 ) === "_" ) {
			return returnValue;
		}

		if ( isMethodCall ) {
			this.each(function() {
				var instance = $(this).data( name ),
					methodValue = instance && $.isFunction( instance[options] ) ?
						instance[ options ].apply( instance, args ) :
						instance;
				if ( methodValue !== instance && methodValue !== undefined ) {
					returnValue = methodValue;
					return false;
				}
			});
		} else {
			this.each(function() {
			    var instance = $(this).data(name);
			    $(this).data(name, new $.sodahrating(this, options));
			    //if (instance) {
			        
				//	instance.option( options || {} ); 
				//} else {
				//	$(this).data( name, new $.sodahrating( this, options ) );
				//}
			});
		}
		return returnValue;
	};

	$.sodahrating = function(element, options) {
		var idname = element.id;
		if ( arguments.length ) {
			this.element = $(element);
			this.options = $.extend(true, {},
				this.options,
				options
			);
			var self = this;
			this.element.bind( "remove.sodahrating", function() {
				self.destroy();
			});
		}		

		//Default
		var default_value = "-1";
		var default_firstvalue = "1";
		var default_count = "5";
		var default_iconcolor = "#444444";
		var default_inputname = "rating";
		var default_type = "star"; //count
		var default_maxsize = "2000"; 
		var default_reverse = "false";
		//customizado para o EA
        var default_iconcolorarray = [];
		var default_uniqueiconcolor = "true";

		//Settings
		var settings_value = (options.value != undefined) ? parseInt(options.value) : parseInt(default_value);
		var settings_firstvalue = (options.firstvalue != undefined) ? parseInt(options.firstvalue) : parseInt(default_firstvalue);
		var settings_count = (options.count != undefined) ? parseInt(options.count) : parseInt(default_count);
		var settings_iconcolor = (options.iconcolor != undefined) ? options.iconcolor : default_iconcolor;
		var settings_inputname = (options.inputname != undefined) ? options.inputname : default_inputname;
		var settings_type = (options.type != undefined) ? options.type.toLowerCase() : default_type;
		var settings_maxsize = (options.maxsize != undefined) ? parseInt(options.maxsize) : parseInt(default_maxsize);
		var settings_reverse = (options.reverse != undefined) ? options.reverse.toLowerCase() : default_reverse;
	    //customizado para o EA
		var settings_iconcolorarray = (options.iconcolorarray != undefined) ? options.iconcolorarray : default_iconcolorarray;
		var settings_uniqueiconcolor = (options.uniqueiconcolor != undefined) ? options.uniqueiconcolor.toLowerCase() : default_uniqueiconcolor;

		var settings_arraycounter = 0;

		//Definition
		var iconstar_empty = '<svg xmlns="http://www.w3.org/2000/svg"xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" x="0px" y="0px" viewBox="0 0 800 800"><path d="M530.98,257.749c71.538,11.511,132.76,19.51,207.287,30.483 c20.707,3.048,53.626,4.592,57.309,20.729c5.121,22.452-27.256,43.107-40.236,56.089c-41.056,41.053-79.478,75.818-121.936,118.275 c-8.208,8.208-20.77,18.663-21.948,25.604c-1.3,7.669,4.319,22.469,6.097,32.923c10.24,60.191,16.986,104.744,28.046,167.049 c3.222,18.145,11.395,55.603,0,64.623c-17.774,14.07-50.549-12.271-64.626-19.509c-62.684-32.23-119.656-62.28-180.46-93.889	c-60.788,29.727-115.38,60.316-178.022,92.67c-14.85,7.669-44.921,31.477-64.625,23.166c-16.181-6.823-8.729-41.813-4.877-63.404 c11.149-62.489,18.781-107.027,29.263-169.486c1.808-10.771,7.157-24.664,6.097-32.923c-1.862-14.511-35.107-38.764-46.333-49.992 c-33.13-33.13-64.459-62.019-97.547-95.107c-13.073-13.073-44.226-32.118-40.238-54.87c3.095-17.657,35.938-18.801,57.309-21.948 c71.4-10.513,133.54-19.535,206.067-29.264c27.325-50.845,60.492-118.302,89.011-178.022c7.426-15.55,22.17-61.267,46.333-58.528 c18.601,2.108,31.761,41.457,37.8,53.651C470.972,137.092,501.589,202.131,530.98,257.749z M309.062,313.838 c-66.289,9.715-132.615,19.394-198.75,29.264c31.286,35.007,72.236,69.797,108.521,106.081c8.933,8.933,33.59,28.14,35.36,37.799	c2.023,11.043-6.417,36.217-8.536,48.773c-8.69,51.503-17.511,100.075-25.606,148.757c61.295-30.153,119.597-63.302,180.461-93.887 c43.714,24.078,90.539,47.533,134.126,70.721c15.098,8.032,28.972,17.811,45.115,21.948c-9.011-47.196-17.598-98.499-25.605-147.539 c-2.17-13.289-11.091-38.986-8.536-49.992c1.974-8.497,26.812-28.031,35.36-36.58c35.192-35.19,69.562-64.518,102.424-97.546 c1.706-1.715,6.669-5.101,4.878-8.535c-65.873-10.131-132.201-19.809-198.751-29.264c-29.723-60.913-59.024-122.249-90.23-181.68 C369.442,192.944,340.124,254.262,309.062,313.838z"/></svg>';
		var iconstar_full = '<svg xmlns="http://www.w3.org/2000/svg"xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" x="0px" y="0px" viewBox="0 0 800 800"><path d="M530.98,257.749c71.538,11.511,132.76,19.51,207.287,30.483	c20.707,3.048,53.626,4.592,57.309,20.729c5.121,22.452-27.256,43.107-40.236,56.089c-41.056,41.053-79.478,75.818-121.936,118.275 c-8.208,8.208-20.77,18.663-21.948,25.604c-1.3,7.669,4.319,22.469,6.097,32.923c10.24,60.191,16.986,104.744,28.046,167.049	c3.222,18.145,11.395,55.603,0,64.623c-17.774,14.07-50.549-12.271-64.626-19.509c-62.684-32.23-119.656-62.28-180.46-93.889 c-60.788,29.727-115.38,60.316-178.022,92.67c-14.85,7.669-44.921,31.477-64.625,23.166c-16.181-6.823-8.729-41.813-4.877-63.404 c11.149-62.489,18.781-107.027,29.263-169.486c1.808-10.771,7.157-24.664,6.097-32.923c-1.862-14.511-35.107-38.764-46.333-49.992 c-33.13-33.13-64.459-62.019-97.547-95.107c-13.073-13.073-44.226-32.118-40.238-54.87c3.095-17.657,35.938-18.801,57.309-21.948 c71.4-10.513,133.54-19.535,206.067-29.264c27.325-50.845,60.492-118.302,89.011-178.022c7.426-15.55,22.17-61.267,46.333-58.528 c18.601,2.108,31.761,41.457,37.8,53.651C470.972,137.092,501.589,202.131,530.98,257.749z"/></svg>';
		var iconcount_empty = '<svg xmlns="http://www.w3.org/2000/svg"xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" x="0px" y="0px" viewBox="0 0 800 800"><g><path d="M400,787.994c-52.361,0-103.177-10.264-151.037-30.507c-46.207-19.544-87.696-47.515-123.316-83.134 c-35.62-35.62-63.59-77.109-83.134-123.316C22.27,503.178,12.006,452.361,12.006,400S22.27,296.823,42.513,248.963 c19.544-46.207,47.514-87.696,83.134-123.316c35.62-35.62,77.109-63.59,123.316-83.134C296.823,22.27,347.639,12.006,400,12.006 S503.178,22.27,551.037,42.513c46.207,19.544,87.696,47.514,123.316,83.134c35.619,35.62,63.59,77.109,83.134,123.316 c20.243,47.86,30.507,98.676,30.507,151.037s-10.264,103.178-30.507,151.037c-19.544,46.207-47.515,87.696-83.134,123.316 c-35.62,35.619-77.109,63.59-123.316,83.134C503.178,777.73,452.361,787.994,400,787.994z M400,92.006 C230.171,92.006,92.006,230.171,92.006,400c0,169.828,138.166,307.994,307.994,307.994c169.828,0,307.994-138.166,307.994-307.994 C707.994,230.171,569.828,92.006,400,92.006z"/></g></svg>';
		var iconcount_full = '<svg xmlns="http://www.w3.org/2000/svg"xmlns:xlink="http://www.w3.org/1999/xlink" version="1.1" x="0px" y="0px" viewBox="0 0 800 800"><g><path d="M400,787.994c-52.361,0-103.177-10.264-151.037-30.507c-46.207-19.544-87.696-47.515-123.316-83.134 c-35.62-35.62-63.59-77.109-83.134-123.316C22.27,503.178,12.006,452.361,12.006,400S22.27,296.823,42.513,248.963	c19.544-46.207,47.514-87.696,83.134-123.316c35.62-35.62,77.109-63.59,123.316-83.134C296.823,22.27,347.639,12.006,400,12.006	S503.178,22.27,551.037,42.513c46.207,19.544,87.696,47.514,123.316,83.134c35.619,35.62,63.59,77.109,83.134,123.316 c20.243,47.86,30.507,98.676,30.507,151.037s-10.264,103.178-30.507,151.037c-19.544,46.207-47.515,87.696-83.134,123.316	c-35.62,35.619-77.109,63.59-123.316,83.134C503.178,777.73,452.361,787.994,400,787.994z M400,92.006 C230.171,92.006,92.006,230.171,92.006,400c0,169.828,138.166,307.994,307.994,307.994c169.828,0,307.994-138.166,307.994-307.994 C707.994,230.171,569.828,92.006,400,92.006z"/></g><g><circle cx="400" cy="400.001" r="213.741"/></g></svg>';
		var inputvalue = -1;
		var latestvalue = -1;
		var icon_full = (settings_type == "star") ? iconstar_full : iconcount_full;
		var icon_empty = (settings_type == "star") ? iconstar_empty : iconcount_empty;

		//Container
		var divname;
		var container;
		var containerinside;
		var ratingsHIT;
		var ratingsTOP;
		var ratingsBACK;
		var ratingsDIV;
		var inputdummy;
		var ratingsCOUNT;

		$(document).ready(function() {
			ini(idname);
		});

		//###############################################################################
		//START
		//###############################################################################
		function ini(idname){
			divname = idname;
			iniDIV();
		}		
        
		//###############################################################################
		//INITIAL DIV
		//###############################################################################
		function iniDIV() {
			container = document.getElementById(divname);
			container.innerHTML = "";
			container.style.overflow = "hidden";
			container.style.display = "block";

			containerinside = document.createElement("div");
			containerinside.id = divname + "_containerinside";
			containerinside.style.position = "relative";
			containerinside.style.left = "0px";
			containerinside.style.top = "0px";
			containerinside.style.height = "100%";
			containerinside.style.width = "100%";
			container.appendChild(containerinside);

			iniRATING();
			resize();
			$(window).resize(function() {
				resize();
			});
		}

		//###############################################################################
		//INITIAL RATING
		//###############################################################################
		function iniRATING() {
			inputdummy = document.createElement("input");
			inputdummy.id = divname + "_inputdummy";
			inputdummy.type = "text";
			inputdummy.name = settings_inputname;
			containerinside.appendChild(inputdummy);
			$('#' + divname + "_inputdummy").css({
				"height": "0px",
				"width": "0px",
				"display" : "none"
			});
			$('#' + divname + "_inputdummy").val(0);

			ratingsDIV = document.createElement("div");
			ratingsDIV.id = divname + "_ratings";
			containerinside.appendChild(ratingsDIV);

			if (settings_type != "star") {
				ratingsCOUNT = document.createElement("div");
				ratingsCOUNT.id = divname + "_ratings_count";
				ratingsDIV.appendChild(ratingsCOUNT);
				$('#' + divname + "_ratings_count").css({
					"position" : "absolute",
					"border" : "none",
					"display": "block",
					"top" : "0px",
					"left" : "0px",
					"width":  "100%"
				});
			}

			ratingsBACK = document.createElement("div");
			ratingsBACK.id = divname + "_ratings_back";
			ratingsDIV.appendChild(ratingsBACK);
			$('#' + divname + "_ratings_back").css({
				"position" : "absolute",
				"border" : "none",
				"display": "block",
				"top" : "0px",
				"left" : "0px",
				"width":  "100%"
			});

			ratingsTOP = document.createElement("div");
			ratingsTOP.id = divname + "_ratings_top";
			ratingsDIV.appendChild(ratingsTOP);
			$('#' + divname + "_ratings_top").css({
				"position" : "absolute",
				"border" : "none",
				"display": "block",
				"top" : "0px",
				"left" : "0px",
				"width":  "100%"
			});

			ratingsHIT = document.createElement("div");
			ratingsHIT.id = divname + "_ratings_hit";
			ratingsDIV.appendChild(ratingsHIT);
			$('#' + divname + "_ratings_hit").css({
				"position" : "absolute",
				"border" : "none",
				"display": "block",
				"top" : "0px",
				"left" : "0px",
				"width":  "100%"
			});
			if (settings_reverse != "true") {
				for (var y = settings_firstvalue; y <= ((settings_firstvalue-1) + settings_count); y++ ) {
				    iniRATINGS(y);
				}
			} else {
				for (var y = ((settings_firstvalue-1) + settings_count); y >= settings_firstvalue; y-- ) {
					iniRATINGS(y);
				}
			}
			settings_arraycounter = 0;
			setRATING(settings_value);
		}
		function iniRATINGS(y) {
			if (settings_type != "star") {
				var ratingCOUNT = document.createElement("div");
				ratingCOUNT.id = divname + "_ratings_count_" + y;
				ratingsCOUNT.appendChild(ratingCOUNT);
				$('#' + divname + "_ratings_count_" + y)
				.html(y)
				.css({
					"display": "block",
					"margin" : "0",
					"padding" : "0",
					"border" : "none",
					"float" : "left",
					"z-index" : "14",
					"text-align" : "center"
				});
			}

			var fill = settings_iconcolor;

			if (settings_uniqueiconcolor !== "true" && settings_iconcolorarray.length > 0 && settings_iconcolorarray.length > settings_arraycounter)
                fill = settings_iconcolorarray[settings_arraycounter];

			var ratingBACK = document.createElement("div");
			ratingBACK.id = divname + "_ratings_back_" + y;
			ratingsBACK.appendChild(ratingBACK);
			$('#' + divname + "_ratings_back_" + y)
			.html(icon_full)
			.css({
				"display": "block",
				"opacity" : "0.0",
				"margin" : "0",
				"padding" : "0",
				"border" : "none",
				"float" : "left",
				"z-index" : "15",
				"cursor": "pointer",
				"text-shadow" : "0px 1px 2px rgba(0, 0, 0, 0.5)",
				"fill": fill
			});

			var ratingTOP = document.createElement("div");
			ratingTOP.id = divname + "_ratings_top_" + y;
			ratingsTOP.appendChild(ratingTOP);
			$('#' + divname + "_ratings_top_" + y)
			.html(icon_empty)
			.css({
				"display": "block",
				"margin" : "0",
				"padding" : "0",
				"border" : "none",
				"float" : "left",
				"z-index" : "16",
				"text-shadow" : "0px 1px 2px rgba(0, 0, 0, 0.5)",
				"fill": fill
			})
			
			var ratingHIT = document.createElement("div");
			ratingHIT.id = divname + "_ratings_hit_" + y;
			ratingsHIT.appendChild(ratingHIT);
			$('#' + divname + "_ratings_hit_" + y)
			.data("ratingnumber", y)
			.css({
				"display": "block",
				"margin" : "0",
				"padding" : "0",
				"border" : "none",
				"opacity" : "0.0",
				"background-color" : "#ffffff",
				"float" : "left",
				"z-index" : "17",
				"cursor": "pointer"
			})
			.mouseenter(function() {
				displayRATING($(this).data("ratingnumber"));
		  	})
		  	.mouseleave(function() {
				displayRATING(inputvalue);
		  	})
			.click(function () {
			    
			   setRATING(y);
			});

			settings_arraycounter++;
		}
		//###############################################################################
		//setRATING
		//###############################################################################
		function setRATING(y) {
		   
			displayRATING(y);
		    inputvalue = y;
			$('#' + divname + "_inputdummy").val(y);
		}

		//###############################################################################
		//DISPLAY MOUSE OVER RATING
		//###############################################################################
		function displayRATING(y){
			var z;
			if (settings_type == "star") {
				for(z = settings_firstvalue; z <= y; z++ ) {
					$('#' + divname + "_ratings_back_" + z).css({
						"opacity" : "1.0"
					});
				}
				for(z = y + settings_firstvalue ; z <= ((settings_firstvalue-1) + settings_count); z++ ) {
					$('#' + divname + "_ratings_back_" + z).css({
						"opacity" : "0.0"
					});
				}
			} else {
				for(z = settings_firstvalue; z <= ((settings_firstvalue-1) + settings_count); z++ ) {
					$('#' + divname + "_ratings_back_" + z).css({
						"opacity" : "0.0"
					});
				}
				$('#' + divname + "_ratings_back_" + y).css({
					"opacity" : "1.0"
				});
			}
		}
		
		//###############################################################################
		//RESIZE
		//###############################################################################
		function resize() {
			var thiswidth = $("#" + divname).width();
			var thisheight = $("#" + divname).height();
			var thisiconsize = thiswidth/settings_count;
			var thispadding = 0;
			if (thisiconsize > settings_maxsize) {
				thisiconsize = settings_maxsize;
				thispadding = Math.floor((thiswidth - (thisiconsize*settings_count))/(settings_count-1));
			}
			if (settings_type == "star") {
				$("#" + divname).css({
					"height" :  thisiconsize + "px"
				})
			} else {
				$("#" + divname).css({
					"height" :  2*thisiconsize + "px"
				})
				$('#' + divname + "_ratings_count").css({
					"top": thisiconsize + "px"
				});
			}
			for (var y = settings_firstvalue; y <= ((settings_firstvalue-1) + settings_count); y++ ) {
				$('#' + divname + "_ratings_top_" + y).css({
					"width":  thisiconsize + "px",
					"height" :  thisiconsize + "px"
				});
				if (y == settings_firstvalue || y == ((settings_firstvalue-1) + settings_count)){
					$('#' + divname + "_ratings_hit_" + y).css({
						"width":  Math.floor(thiswidth/(settings_count-1)/2) + "px"
					});
				} else {
					$('#' + divname + "_ratings_hit_" + y).css({
						"width":  thiswidth/(settings_count-1) + "px"
					});
				}
				$('#' + divname + "_ratings_back_" + y).css({
					"width":  thisiconsize + "px",
					"height" :  thisiconsize + "px"
				});
				if (settings_type != "star") {
					$('#' + divname + "_ratings_count_" + y).css({
						"width":  thisiconsize + "px",
						"height" :  thisiconsize + "px",
						"font-size":  thisiconsize/1.5 + "px",
						"line-height" :  thisiconsize + "px"
					});
					$('#' + divname + "_ratings_hit_" + y).css({
						"height":  2*thisiconsize + "px"
					});
				} else {
					$('#' + divname + "_ratings_hit_" + y).css({
						"height":  thisiconsize + "px"
					});
				}
				if ((y != ((settings_firstvalue-1) + settings_count)) && (settings_reverse != "true")){
					$('#' + divname + "_ratings_top_" + y).css({
						"margin-right": thispadding + "px"
					});
					$('#' + divname + "_ratings_back_" + y).css({
						"margin-right": thispadding + "px"
					});
					if (settings_type != "star") {
						$('#' + divname + "_ratings_count_" + y).css({
							"margin-right": thispadding + "px"
						});
					}
				}
				if ((y != settings_firstvalue) && (settings_reverse == "true")){
					$('#' + divname + "_ratings_top_" + y).css({
						"margin-right": thispadding + "px"
					});
					$('#' + divname + "_ratings_back_" + y).css({
						"margin-right": thispadding + "px"
					});
					if (settings_type != "star") {
						$('#' + divname + "_ratings_count_" + y).css({
							"margin-right": thispadding + "px"
						});
					}
				}
			}
		}
	};
}));