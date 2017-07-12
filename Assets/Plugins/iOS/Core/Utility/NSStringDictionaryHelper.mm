//
//  unityMCtest.m
//  unityMCtest
//
//  Created by Alexander Chocron on 6/9/17.
//  Copyright © 2017 Alexander Chocron. All rights reserved.
//

#import "NSStringDictionaryHelper.h"
#import "NSStringHelper.h"
#import <Foundation/Foundation.h>

char* mobile_center_unity_ns_string_dictionary_get_key_at_idx(NSDictionary *dictionary, int idx)
{
  id sortKeys = ^(NSString * key1, NSString * key2){
    return [key1 compare:key2];
  };
  NSArray *keys = [[dictionary allKeys] sortedArrayUsingComparator:sortKeys];
  return mobile_center_unity_ns_string_to_cstr(keys[idx]);
}

char* mobile_center_unity_ns_string_dictionary_get_value_for_key(NSDictionary *dictionary, char* key)
{
  NSString * keyString  = [NSString stringWithUTF8String:key];
  return mobile_center_unity_ns_string_to_cstr([dictionary objectForKey:keyString]);
}

NSDictionary* mobile_center_unity_create_ns_string_dictionary(char** keys, char** values, int count)
{
  // Convert the two arrays to a single dictionary
  NSMutableDictionary<NSString*, NSString*> *nsdictionary = [[NSMutableDictionary<NSString*, NSString*> alloc] init];
  for (int i = 0; i < count; ++i)
  {
    NSString * key = [NSString stringWithUTF8String:keys[i]];
    NSString * value = [NSString stringWithUTF8String:values[i]];
    [nsdictionary setValue:value forKey:key];
  }
  return nsdictionary;
}

size_t mobile_center_unity_ns_dictionary_get_length(NSDictionary *dictionary)
{
  return [dictionary count];
}
