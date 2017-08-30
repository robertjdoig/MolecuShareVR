Shader "Custom/VertexColor" {
    SubShader {
    Pass {
        LOD 200
              

       /* Tags{
       https://stackoverflow.com/questions/32330902/add-alpha-to-shader-in-unity3d
          "Queue" = "Transparent"
          "IgnoreProjector" = "True"
          "RenderType" = "Transparent"
        }

        Pass*/

        /** Added to allow the use of the alpha channel : ROB */
        //Lighting Off
        //Fog { Mode Off }
       // ZWrite Off
        //Blend SrcAlpha OneMinusSrcAlpha  
        /** Alpha Channel End */
                 
        CGPROGRAM
        #pragma vertex vert
        #pragma fragment frag
  
        struct VertexInput {
            float4 v : POSITION;
            float4 color: COLOR;
                
    };
         
        struct VertexOutput {
            float4 pos : SV_POSITION;
            float4 col : COLOR;
        };
         
        VertexOutput vert(VertexInput v) {
         
            VertexOutput o;
            o.pos = mul(UNITY_MATRIX_MVP, v.v);
            o.col = v.color;
            //o.a = v.a;
            return o;
        }
         
        float4 frag(VertexOutput o) : COLOR {
           
          return o.col;
        }
 
        ENDCG
        } 
    }
 
}
