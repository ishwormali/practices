var numStack=[];
		$('#calculator-container').click(function(e){
			var targ=e.target;
			var calcFn=$(targ).val();
			var numericValue=parseInt(calcFn);
			var currentValue=$('.result').val();
			if((numericValue>=0 && numericValue<=9)) {

				$('.result').val((currentValue+'')+(numericValue+''));

			}
			else if (calcFn=='.' || calcFn=='+'|| calcFn=='-'|| calcFn=='*'|| calcFn=='/') {

				numStack.push(parseFloat(currentValue));
				$('.result').val('');
				numStack.push(calcFn);
			}
			else if(calcFn=='='){
				if (currentValue!='') {
					
					if (numStack.length>=2) {
						numStack.push(parseFloat(currentValue));
						var finalResult=eval(numStack.join(' '));
						$('.result').val(finalResult);
						clearArray(numStack);
						//numStack.push(finalResult);
					}
				};
				
			}
			else if (calcFn=='C'){
				clearArray(numStack);
				$('.result').val('');
			}
		});

		function clearArray(arr){ 
			//or arr=[];
			var arrlength=arr.length;
			for (var i = 0; i < arrlength; i++) {
				arr.pop();
			};
		}