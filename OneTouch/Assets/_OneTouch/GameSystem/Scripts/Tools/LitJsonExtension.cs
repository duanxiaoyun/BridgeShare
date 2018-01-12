using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace LitJson{
    public static class LitJsonExtension {
        [CLSCompliant(false)]
        public static void WriteProperty(this JsonWriter writer,string key,ulong value){
            writer.WritePropertyName(key);
            writer.Write(value);
        }

        public static void WriteProperty(this JsonWriter writer,string key,string value)
        {
            writer.WritePropertyName(key);
            if(string.IsNullOrEmpty(value))
                writer.Write("");
            else 
                writer.Write(value);
        }

        public static void WriteProperty(this JsonWriter writer,string key,long value)
        {
            writer.WritePropertyName(key);
            writer.Write(value);
        }

        public static void WriteProperty(this JsonWriter writer,string key,int value)
        {
            writer.WritePropertyName(key);
            writer.Write(value);
        }
        public static void WriteProperty(this JsonWriter writer,string key,double value)
        {
            writer.WritePropertyName(key);
            writer.Write(value);
        }
        public static void WriteProperty(this JsonWriter writer,string key,decimal value)
        {
            writer.WritePropertyName(key);
            writer.Write(value);
        }
        public static void WriteProperty(this JsonWriter writer,string key,bool value)
        {
            writer.WritePropertyName(key);
            writer.Write(value);
        }


        public static int ToInt32(this JsonData data){
            if (data.IsInt)
                return (int)data;
            else if (data.IsBoolean)
                return Convert.ToInt32((bool)data);
            else if (data.IsLong)
                return Convert.ToInt32((long)data);
            else if(data.IsString)
                return Convert.ToInt32((string)data);
            else if(data.IsObject)
                return Convert.ToInt32((object)data);
            else if (data.IsDouble)
                return Convert.ToInt32((double)data);
            else
                return 0;
        }

        public static string ToString(this JsonData data){
            if(data.IsString)
                return (string)data;
            else if (data.IsLong)
                return Convert.ToString((long)data);
            else if(data.IsInt)
                return Convert.ToString((int)data);
            else if(data.IsObject)
                return Convert.ToString((object)data);
            else if (data.IsDouble)
                return Convert.ToString((double)data);
            else if (data.IsBoolean)
                return Convert.ToString((bool)data);
            else 
                return "";
        }

        public static long ToInt64(this JsonData data){
            if (data.IsLong)
                return (long)data;
            else if(data.IsInt)
                return Convert.ToInt64((int)data);
            else if(data.IsString)
                return Convert.ToInt64((string)data);
            else if (data.IsBoolean)
                return Convert.ToInt64((bool)data);
            else if (data.IsDouble)
                return Convert.ToInt64((double)data);
            else if(data.IsObject)
                return Convert.ToInt64((object)data);
            else
                return 0;
        }

        public static float ToSingle(this JsonData data){
            if (data.IsDouble)
                return Convert.ToSingle((double)data);
            else if(data.IsInt)
                return Convert.ToSingle((int)data);
            else if(data.IsString)
                return Convert.ToSingle((string)data);
            else if (data.IsBoolean)
                return Convert.ToSingle((bool)data);
            else if (data.IsLong)
                return Convert.ToSingle((long)data);
            else if(data.IsObject)
                return Convert.ToSingle((object)data);
            else
                return 0;
        }

        public static double ToDouble(this JsonData data){
            if (data.IsDouble)
                return (double)data;
            else if(data.IsInt)
                return Convert.ToDouble((int)data);
            else if(data.IsString)
                return Convert.ToDouble((string)data);
            else if (data.IsBoolean)
                return Convert.ToDouble((bool)data);
            else if (data.IsLong)
                return Convert.ToDouble((long)data);
            else if(data.IsObject)
                return Convert.ToDouble((object)data);
            else
                return 0;
        }

        public static bool ToBoolean(this JsonData data){
            if (data.IsBoolean)
                return (bool)data;
            else if (data.IsInt)
                return Convert.ToBoolean(ToInt32(data));
            else if(data.IsDouble)
                return Convert.ToBoolean((double)data);
            else if(data.IsString)
                return Convert.ToBoolean((string)data);
            else if (data.IsLong)
                return Convert.ToBoolean((long)data);
            else if(data.IsObject)
                return Convert.ToBoolean((object)data);
            else
                return false;
        }

        public static DateTime ToDateTime(this JsonData data){
            if (data.IsString){
                if (string.IsNullOrEmpty((string)data))
                    return DateTime.MinValue;
                else
                    return Convert.ToDateTime((string)data);
            }else if (data.IsLong)
                return Convert.ToDateTime((long)data);
            else if(data.IsObject)
                return Convert.ToDateTime((object)data);
            else if (data.IsInt)
                return Convert.ToDateTime((int)data);
            else if(data.IsBoolean)
                return Convert.ToDateTime((bool)data);
            else if(data.IsDouble)
                return Convert.ToDateTime((double)data);
            else
                return DateTime.MinValue;
        }

        public static int OptInt32(this JsonData data,string key){
            if (data.Keys.Contains(key) && data[key] != null)
            {
                return data[key].ToInt32();
            }
            return 0;
        }

        public static string OptString(this JsonData data,string key){
            if (data.Keys.Contains(key) && data[key] != null)
            {
                return data[key].ToString();
            }
            return "";
        }

        public static long OptInt64(this JsonData data,string key){
            if (data.Keys.Contains(key) && data[key] != null)
            {
                return data[key].ToInt64();
            }
            return 0;
        }

        public static float OptSingle(this JsonData data,string key){
            if (data.Keys.Contains(key) && data[key] != null)
            {
                return data[key].ToSingle();
            }
            return 0;
        }

        public static double OptDouble(this JsonData data,string key){
            if (data.Keys.Contains(key) && data[key] != null)
            {
                return data[key].ToDouble();
            }
            return 0;
        }

        public static bool OptBoolean(this JsonData data,string key){
            if (data.Keys.Contains(key) && data[key] != null)
            {
                return data[key].ToBoolean();
            }
            return false;
        }

        public static DateTime OptDateTime(this JsonData data,string key){
            if (data.Keys.Contains(key) && data[key] != null)
            {
                return data[key].ToDateTime();
            }
            return DateTime.MinValue;
        }

        public static bool ContainsKeyAndNotNull(this JsonData data, string key){
            //Debug.Log(key);
            //Debug.Log(data[key]);
            return data.Keys.Contains(key) && data[key] != null;
        }
    }
}
