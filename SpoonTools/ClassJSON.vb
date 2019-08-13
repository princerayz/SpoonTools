Imports Newtonsoft.Json

Module ClassJSON
    Public Class CurrentLive
        Public Property id As Integer
    End Class

    Public Class Author
        Public Property id As Integer
        Public Property nickname As String
        Public Property tag As String
        Public Property top_impressions As Integer()
        Public Property description As String
        Public Property profile_url As String
        Public Property gender As Integer
        Public Property follow_status As Integer
        Public Property follower_count As Integer
        Public Property following_count As Integer
        Public Property is_active As Boolean
        Public Property is_staff As Boolean
        Public Property date_joined As DateTime
        Public Property current_live As CurrentLive
        Public Property country As String
    End Class

    Public Class User
        Public Property id As Integer
        Public Property nickname As String
        Public Property tag As String
        Public Property top_impressions As Integer()
        Public Property description As String
        Public Property profile_url As String
        Public Property gender As Integer
        Public Property follow_status As Integer
        Public Property follower_count As Integer
        Public Property following_count As Integer
        Public Property is_active As Boolean
        Public Property is_staff As Boolean
        Public Property date_joined As DateTime
        Public Property current_live As Object
        Public Property country As String
    End Class

    Public Class TopFan
        Public Property user As User
    End Class

    Public Class Result
        Public Property id As Integer
        Public Property author As Author
        Public Property title As String
        Public Property welcome_message As String
        Public Property type As Integer
        Public Property top_fans As TopFan()
        Public Property url As String
        Public Property url_hls As String
        Public Property url_rtsp As String
        Public Property img_url As String
        Public Property status As Integer
        Public Property stream_name As String
        Public Property manager_ids As Integer()
        Public Property like_count As Integer
        Public Property total_member_count As Integer
        Public Property member_count As Integer
        Public Property is_editors As Boolean
        Public Property tier As Object
        Public Property is_adult As Boolean
        Public Property is_like As Boolean
        Public Property is_save As Boolean
        Public Property is_mute As Boolean
        Public Property is_freeze As Boolean
        Public Property is_call As Boolean
        Public Property is_join_now As Boolean
        Public Property created As DateTime
        Public Property closed As Object
        Public Property close_status As Integer
        Public Property categories As String()
        Public Property protocol As String
        Public Property tags As Object()
        Public Property engine_name As String
    End Class

    Public Class SpoonStruct
        Public Property status_code As Integer
        Public Property detail As String
        Public Property results As Result()
    End Class


    Public Class Budget
        Public Property present_spoon As Integer
        Public Property purchase_spoon As Integer
        Public Property total_exchange_spoon As Integer
        Public Property exchange_price_per_spoon As Integer
    End Class

    Public Class Grants
        Public Property login As Integer
        Public Property cast As Integer
        Public Property talk As Integer
        Public Property live As Integer
        Public Property adult As Integer
        Public Property phone As Integer
        Public Property payment As Integer
    End Class

    Public Class PushSettings
        Public Property bj As Boolean
        Public Property follow As Boolean
        Public Property like_or_present As Boolean
        Public Property comment_or_mention_cast As Boolean
        Public Property comment_or_mention_talk As Boolean
        Public Property comment_or_mention_board As Boolean
        Public Property event_or_marketing As Boolean
    End Class

    Public Class ResultUser
        Public Property id As Integer
        Public Property nickname As String
        Public Property tag As String
        Public Property sns_type As String
        Public Property description As String
        Public Property profile_url As String
        Public Property date_joined As DateTime
        Public Property follower_count As Integer
        Public Property following_count As Integer
        Public Property token As String
        Public Property budget As Budget
        Public Property grants As Grants
        Public Property push_settings As PushSettings
        Public Property is_active As Boolean
        Public Property is_exist As Boolean
        Public Property is_staff As Boolean
        Public Property result_code As Integer
        Public Property result_message As String
        Public Property is_choice As Boolean
        Public Property tier As Object
        Public Property country As String
        Public Property service_agreement As Object
    End Class

    Public Class ResultCast
        Public Property id As Integer
        Public Property author As Author
        Public Property title As String
        Public Property img_url As String
        Public Property voice_url As String
        Public Property tags As Object()
        Public Property type As Integer
        Public Property like_count As Integer
        Public Property play_count As Integer
        Public Property text_comment_count As Integer
        Public Property spoon_count As Integer
        Public Property duration As Double
        Public Property reporters As Object()
        Public Property is_donated As Boolean
        Public Property is_like As Boolean
        Public Property created As DateTime
        Public Property is_storage As Boolean
    End Class
    Public Class SpoonCastStrut
        Public Property status_code As Integer
        Public Property detail As String
        Public Property results As ResultCast()
    End Class

    Public Class SpoonUserStruct
        Public Property status_code As Integer
        Public Property detail As String
        Public Property results As ResultUser()
    End Class


End Module

Public Module JsonHelper

    Public Function FromClass(Of T)(data As T,
                                    Optional isEmptyToNull As Boolean = False,
                                    Optional jsonSettings As JsonSerializerSettings = Nothing) As String

        Dim response As String = String.Empty

        If Not EqualityComparer(Of T).Default.Equals(data, Nothing) Then
            response = JsonConvert.SerializeObject(data, jsonSettings)
        End If

        Return If(isEmptyToNull, (If(response = "{}", "null", response)), response)

    End Function

    Public Function ToClass(Of T)(data As String,
                                  Optional jsonSettings As JsonSerializerSettings = Nothing) As T

        Dim response = Nothing

        If Not String.IsNullOrEmpty(data) Then
            response = If(jsonSettings Is Nothing,
                JsonConvert.DeserializeObject(Of T)(data),
                JsonConvert.DeserializeObject(Of T)(data, jsonSettings))
        End If

        Return response

    End Function



End Module
