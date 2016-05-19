var mxwvalue [];
mxwvalue[0] = mxw.widget("/mxw/track/1").getValue();
mxwvalue[1] = mxw.widget("/mxw/track/1/layer/3/opacity").getValue();
mxwvalue[2] = mxw.widget("/mxw/track/1/layer/2/opacity").getValue();
mxwvalue[3] = mxw.widget("/mxw/track/2").getValue();
mxwvalue[4] = mxw.widget("/mxw/track/2/layer/3/opacity").getValue();
mxwvalue[5] = mxw.widget("/mxw/track/2/layer/2/opacity").getValue();
mxwvalue[6] = mxw.widget("/mxw/track/3").getValue();
mxwvalue[7] = mxw.widget("/mxw/track/3/layer/3/opacity").getValue();
mxwvalue[8] = mxw.widget("/mxw/track/3/layer/2/opacity").getValue();
mxwvalue[9] = mxw.widget("/mxw/render/scale").getValue();
mxwvalue[10] = mxw.widget("/mxw/render/rotation").getValue();
mxwvalue[11] = mxw.widget("/mxw/render/translationx").getValue();
mxwvalue[12] = mxw.widget("/mxw/render/translationy").getValue();
mxwvalue[13] = mxw.widget("/mxw/render/opacity").getValue();
mxwvalue[14] = mxw.widget("/mxw/render/effect/1/param/1").getValue();
				
var mxwvaluearrayLength = mxwvalues.length;



function on_trigger()
{
mxwvalue[0] = mxw.widget("/mxw/track/1").getValue();
mxwvalue[1] = mxw.widget("/mxw/track/1/layer/3/opacity").getValue();
mxwvalue[2] = mxw.widget("/mxw/track/1/layer/2/opacity").getValue();
mxwvalue[3] = mxw.widget("/mxw/track/2").getValue();
mxwvalue[4] = mxw.widget("/mxw/track/2/layer/3/opacity").getValue();
mxwvalue[5] = mxw.widget("/mxw/track/2/layer/2/opacity").getValue();
mxwvalue[6] = mxw.widget("/mxw/track/3").getValue();
mxwvalue[7] = mxw.widget("/mxw/track/3/layer/3/opacity").getValue();
mxwvalue[8] = mxw.widget("/mxw/track/3/layer/2/opacity").getValue();
mxwvalue[9] = mxw.widget("/mxw/render/scale").getValue();
mxwvalue[10] = mxw.widget("/mxw/render/rotation").getValue();
mxwvalue[11] = mxw.widget("/mxw/render/translationx").getValue();
mxwvalue[12] = mxw.widget("/mxw/render/translationy").getValue();
mxwvalue[13] = mxw.widget("/mxw/render/opacity").getValue();
mxwvalue[14] = mxw.widget("/mxw/render/effect/1/param/1").getValue();


for (var i = 0;i < mxwvaluearrayLength; i++) {

print_console(mxwvalue[i]);

}

mxw.send_midi(1,1,mxwvalue[0]); 
mxw.send_midi(1,11,mxwvalue[1]); 
mxw.send_midi(1,12,mxwvalue[2]); 
mxw.send_midi(1,2,mxwvalue[3]); 
mxw.send_midi(1,21,mxwvalue[4]); 
mxw.send_midi(1,22,mxwvalue[5]); 
mxw.send_midi(1,3,mxwvalue[6]); 
mxw.send_midi(1,31,mxwvalue[7]); 
mxw.send_midi(1,32,mxwvalue[8]); 
mxw.send_midi(16,1,mxwvalue[9]); 
mxw.send_midi(16,2,mxwvalue[10]); 
mxw.send_midi(16,3,mxwvalue[11]); 
mxw.send_midi(16,4,mxwvalue[12]); 


} 
