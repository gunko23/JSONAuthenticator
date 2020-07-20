using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;

namespace JSONDeserializer
{
    class Program
    {

    public partial class Conversations
    {
        [JsonProperty("conversations")]
        public ConversationElement[] ConversationsConversations { get; set; }
    }

    public partial class ConversationElement
    {
        [JsonProperty("conversation")]
        public PurpleConversation Conversation { get; set; }

        [JsonProperty("events")]
        public Event[] Events { get; set; }
    }

    public partial class PurpleConversation
    {
        [JsonProperty("conversation_id")]
        public ConversationId ConversationId { get; set; }

        [JsonProperty("conversation")]
        public FluffyConversation Conversation { get; set; }
    }

    public partial class FluffyConversation
    {
        [JsonProperty("id")]
        public ConversationId Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("self_conversation_state")]
        public SelfConversationState SelfConversationState { get; set; }

        [JsonProperty("read_state")]
        public ReadState[] ReadState { get; set; }

        [JsonProperty("has_active_hangout")]
        public bool HasActiveHangout { get; set; }

        [JsonProperty("otr_status")]
        public string OtrStatus { get; set; }

        [JsonProperty("otr_toggle")]
        public string OtrToggle { get; set; }

        [JsonProperty("current_participant")]
        public SenderId[] CurrentParticipant { get; set; }

        [JsonProperty("participant_data")]
        public ParticipantDatum[] ParticipantData { get; set; }

        [JsonProperty("fork_on_external_invite")]
        public bool ForkOnExternalInvite { get; set; }

        [JsonProperty("network_type")]
        public string[] NetworkType { get; set; }

        [JsonProperty("force_history_state")]
        public string ForceHistoryState { get; set; }

        [JsonProperty("group_link_sharing_status")]
        public string GroupLinkSharingStatus { get; set; }
    }

    public partial class SenderId
    {
        [JsonProperty("gaia_id")]
        public string GaiaId { get; set; }

        [JsonProperty("chat_id")]
        public string ChatId { get; set; }
    }

    public partial class ConversationId
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class ParticipantDatum
    {
        [JsonProperty("id")]
        public SenderId Id { get; set; }

        [JsonProperty("fallback_name")]
        public string FallbackName { get; set; }

        [JsonProperty("invitation_status")]
        public string InvitationStatus { get; set; }

        [JsonProperty("participant_type")]
        public string ParticipantType { get; set; }

        [JsonProperty("new_invitation_status")]
        public string NewInvitationStatus { get; set; }

        [JsonProperty("in_different_customer_as_requester")]
        public bool InDifferentCustomerAsRequester { get; set; }

        [JsonProperty("domain_id")]
        public string DomainId { get; set; }
    }

    public partial class ReadState
    {
        [JsonProperty("participant_id")]
        public SenderId ParticipantId { get; set; }

        [JsonProperty("latest_read_timestamp")]
        public string LatestReadTimestamp { get; set; }
    }

    public partial class SelfConversationState
    {
        [JsonProperty("self_read_state")]
        public ReadState SelfReadState { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("notification_level")]
        public string NotificationLevel { get; set; }

        [JsonProperty("view")]
        public string[] View { get; set; }

        [JsonProperty("inviter_id")]
        public SenderId InviterId { get; set; }

        [JsonProperty("invite_timestamp")]
        public string InviteTimestamp { get; set; }

        [JsonProperty("sort_timestamp")]
        public string SortTimestamp { get; set; }

        [JsonProperty("active_timestamp")]
        public string ActiveTimestamp { get; set; }

        [JsonProperty("delivery_medium_option")]
        public DeliveryMediumOption[] DeliveryMediumOption { get; set; }

        [JsonProperty("is_guest")]
        public bool IsGuest { get; set; }
    }

    public partial class DeliveryMediumOption
    {
        [JsonProperty("delivery_medium")]
        public DeliveryMedium DeliveryMedium { get; set; }

        [JsonProperty("current_default")]
        public bool CurrentDefault { get; set; }
    }

    public partial class DeliveryMedium
    {
        [JsonProperty("medium_type")]
        public string MediumType { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("conversation_id")]
        public ConversationId ConversationId { get; set; }

        [JsonProperty("sender_id")]
        public SenderId SenderId { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("self_event_state")]
        public SelfEventState SelfEventState { get; set; }

        [JsonProperty("chat_message", NullValueHandling = NullValueHandling.Ignore)]
        public ChatMessage? ChatMessage { get; set; }

        [JsonProperty("event_id")]
        public string EventId { get; set; }

        [JsonProperty("advances_sort_timestamp")]
        public bool AdvancesSortTimestamp { get; set; }

        [JsonProperty("event_otr")]
        public string EventOtr { get; set; }

        [JsonProperty("delivery_medium")]
        public DeliveryMedium DeliveryMedium { get; set; }

        [JsonProperty("event_type")]
        public string EventType { get; set; }

        [JsonProperty("event_version")]
        public string EventVersion { get; set; }

        [JsonProperty("membership_change", NullValueHandling = NullValueHandling.Ignore)]
        public MembershipChange MembershipChange { get; set; }
    }

    public partial class ChatMessage
    {
        [JsonProperty("message_content")]
        public MessageContent MessageContent { get; set; }
    }

    public partial class MessageContent
    {
        [JsonProperty("segment")]
        public Segment[] Segment { get; set; }

        [JsonProperty("attachment", NullValueHandling = NullValueHandling.Ignore)]
        public Attachment[] Attachment { get; set; }
    }

    public partial class Attachment
    {
        [JsonProperty("embed_item")]
        public EmbedItem EmbedItem { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class EmbedItem
    {
        [JsonProperty("type")]
        public string[] Type { get; set; }

        [JsonProperty("plus_photo")]
        public PlusPhoto PlusPhoto { get; set; }
    }

    public partial class PlusPhoto
    {
        [JsonProperty("thumbnail")]
        public Thumbnail Thumbnail { get; set; }

        [JsonProperty("owner_obfuscated_id")]
        public string OwnerObfuscatedId { get; set; }

        [JsonProperty("album_id")]
        public string AlbumId { get; set; }

        [JsonProperty("photo_id")]
        public string PhotoId { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("media_type")]
        public string MediaType { get; set; }

        [JsonProperty("stream_id")]
        public string[] StreamId { get; set; }
    }

    public partial class Thumbnail
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("width_px")]
        public long WidthPx { get; set; }

        [JsonProperty("height_px")]
        public long HeightPx { get; set; }
    }

    public partial class Segment
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class MembershipChange
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("participant_id")]
        public SenderId[] ParticipantId { get; set; }

        [JsonProperty("leave_reason")]
        public string LeaveReason { get; set; }
    }

    public partial class SelfEventState
    {
        [JsonProperty("user_id")]
        public SenderId UserId { get; set; }

        [JsonProperty("notification_level")]
        public string NotificationLevel { get; set; }

        [JsonProperty("client_generated_id", NullValueHandling = NullValueHandling.Ignore)]
        public string ClientGeneratedId { get; set; }
    }


        static void Main(string[] args)
        {
            JsonSerializer serializer = new JsonSerializer();
            Conversations conversations = new Conversations();
            using (FileStream s = File.Open(@"C:\Users\Mike Gunko\Downloads\Hangouts.json", FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    conversations = serializer.Deserialize<Conversations>(reader);
                }
            }

            var nameLookup = new Dictionary<string, string>();
            var conversationDictionary = new Dictionary<string, List<string>>();


            using (var context = new Context())
            {
                for (int i = 0; i < conversations.ConversationsConversations.Length; i++)
                {
                    if (conversations.ConversationsConversations[i].Conversation != null && conversations.ConversationsConversations[i].Conversation.Conversation != null)
                    {
                        var conversationId = conversations.ConversationsConversations[i].Conversation.Conversation.Id.Id;
                        var newList = new List<string>();
                        foreach (var item in conversations.ConversationsConversations[i].Conversation.Conversation.CurrentParticipant)
                        {
                            newList.Add(item.GaiaId);
                        }
                        conversationDictionary.Add(conversationId, newList);
                        if (conversations.ConversationsConversations[i].Conversation.Conversation.GetType().GetProperty("ParticipantData") != null)
                        {
                            for (int x = 0; x < conversations.ConversationsConversations[i].Conversation.Conversation.ParticipantData.Length; x++)
                            {
                                if (conversations.ConversationsConversations[i].Conversation.Conversation.ParticipantData[x].GetType().GetProperty("FallbackName") != null)
                                {
                                    if (!nameLookup.ContainsKey(conversations.ConversationsConversations[i].Conversation.Conversation.ParticipantData[x].Id.GaiaId))
                                    {
                                        var name = conversations.ConversationsConversations[i].Conversation.Conversation.ParticipantData[x].FallbackName;
                                        if (name != null && name.Contains("Megan Cassidy"))
                                        {
                                            name = "Megan Cassidy";
                                        }
                                        nameLookup.Add(conversations.ConversationsConversations[i].Conversation.Conversation.ParticipantData[x].Id.GaiaId, name);
                                    }
                                }

                            }
                        }
                    }
                    for (int j = 0; j < conversations.ConversationsConversations[i].Events.Length; j++)
                    {
                        if (conversations.ConversationsConversations[i].Events[j].GetType().GetProperty("ChatMessage") != null && 
                            conversations.ConversationsConversations[i].Events[j].ChatMessage != null)
                        {
                            if (conversations.ConversationsConversations[i].Events[j].ChatMessage.MessageContent != null  && 
                                conversations.ConversationsConversations[i].Events[j].ChatMessage.MessageContent.Segment != null && 
                                conversations.ConversationsConversations[i].Events[j].ChatMessage.MessageContent.GetType().GetProperty("Segment") != null)
                            {
                                var item = conversations.ConversationsConversations[i].Events[j];
                                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                                var editedDate = date.AddMilliseconds(long.Parse(item.Timestamp)/1000);
                                var recipientString = "";
                                var conArray = conversationDictionary[item.ConversationId.Id];
                                for (var m = 0; m < conArray.Count; m++)
                                {
                                    var value = conArray[m];
                                    if (value != "117404079371032110458" && value != item.SenderId.GaiaId)
                                    {
                                        recipientString += $"{(nameLookup.ContainsKey(value) ? nameLookup[value] : "")}{((m + 1) != conArray.Count ? ", " : "")}";
                                    }
                                }
                                var messages = new Messages()
                                {
                                    Message = item.ChatMessage.MessageContent.Segment[0].Text,
                                    UserId = item.SenderId.GaiaId,
                                    Date = editedDate,
                                    Name = nameLookup.ContainsKey(item.SenderId.GaiaId) ? nameLookup[item.SenderId.GaiaId] : null,
                                    ConversationId = item.ConversationId.Id,
                                    Recipients = recipientString
                                };

                                if (messages.Name == "Dan Gunko")
                                {
                                    if (messages.Recipients == "Megan Cassidy")
                                    {
                                        context.Add(messages);
                                    }
                                }

                                if (messages.Name == "Megan Cassidy")
                                {
                                    if (messages.Recipients == "")
                                    {
                                        context.Add(messages);
                                    }
                                }

                            }
                        };
                    }
                }

                context.SaveChanges();
            }






        }
    }
}
