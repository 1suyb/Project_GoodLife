using System;
using System.Collections.Generic;
using System.Text;

namespace JsonClassMaker
{
    class StructFormat
    {
        // {0} : 데이터 타입 이름 / 번호 목록
        // {1} : JsonUtil 목록
        // {2} : class 목록
        public static string fileFormat =
@"
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DataType
{{
    {0}
}}

public static class JsonUtil
{{
    {1}
}}

public class Table
{{
    public int ID;
}}
{2}

";
        // {0} : type 이름
        // {1} : type 번호
        public static string enumFormat =
@"
{0} = {1};
";
        #region JsonUtil
        // {0} : case 문
        public static string jsonUtilConverTypeFormat =
@"
    private static string ConvertType(DataType datatype)
    {{
        string filename;
        switch(datatype){
         {0}
        default :
            filename = "";
            break;
        }
        return filename;
    }}
;";
        // {0} : type 이름 (대문자)
        // {1} : type에 따른 파일이름 (DataTable 이름)
        public static string jsonUtilCaseFormat =
@"
    case {0} : 
        filename = {1};
        break;
";
        // {0} : DataTable 이름
        public static string jsonUtilDeserializeFormat =
@"
    public static List<{0}> {0}Deserialize(DataType datatype)
    {{
        String{0}[] t = JsonHelper.Deserialize<String{0}>(ConvertType(datatype));
        List<{0}> l = String{0}.Convert(t);
        return l;
    }}
";
        #endregion

        #region Class
        // {0} : DataTable이름
        // {1} : 맴버 변수
        // {2} : 매개 변수
        // {3} : 변수 초기화 부분
        // {4} : 문자열 클래스 맴버 변수
        // {5} : 생성자 초기화 매개변수
        public static string classFormat =
@"
public class {0} : Table
{{
    {1}
    public {0}({2})
    {{
        {3}
    }}
}}

public class String{0}
{{
    {4}

    public static List<{0}> Convert(String{0}[] table)
    {{
        List<{0}> t = new List<{0}>();
        foreach (Stirng{0} item in table)
        {{
            t.Add(new {0}({5});
        }}
        return t;
    }}
}}
";
        // {0} : 변수
        public static string fullvalueFormat = 
@"
public {0};
";
        // {0} : 변수 형식
        // {1} : 변수 이름
        public static string valueFormat = 
@"
{0} {1}
";
        #endregion
    }
}
