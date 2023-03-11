using DataLibrary;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using VesterbroMMS.Shared;
using VesterbroMMS.Model;
using System;

namespace VesterbroMMS.Services
{
    public class MemberService : Service
    {
        public MemberService(IConfiguration config) : base(config) { }

        public Task InsertMemberAsync(Member member)
        {
            string sql = "INSERT INTO Members (id, name) VALUES (@id, @name);";

            return _dataAccess.SaveData(sql, new { id = member.Id, name = member.Name }, _config.GetConnectionString("default"));
        }

        public Task<List<Member>> GetMembers()
        {
            string sql = "SELECT * FROM MEMBERS;";

            Task<List<Member>> members = _dataAccess.LoadData<Member, dynamic>(sql, new { }, _config.GetConnectionString("default"));

            return members;
        }

        public Task DeleteMember(int id)
        {
            string sql = "DELETE FROM MEMBERS WHERE MEMBERS.ID = @id";

            return _dataAccess.SaveData(sql, new { id = id }, _config.GetConnectionString("default"));
        }

        public Task<List<Member>> AcquireMembers()
        {
            Member Giocomo = new Member(1, "Giocomo", "me@Gio.dk", "Hellostreet 1", "80000085", "010101-0101", new DateTime(1), false);
            Member Hans = new Member(2, "Hans", "hans@hans.dk", "Hansstræde 17", "99999999", "070707-1011", new DateTime(020220), true);
            Member Lars = new Member(3, "Lars Larsen", "lars@larsen.dk", "Larsen's vej", "12345678", "010190-1235", new DateTime(01012019), false);
            Member Per = new Member(4, "Per Larsen", "per@larsen.dk", "Larsen's vej", "23456789", "010190-1237", new DateTime(02012019), false);
            Member Ole = new Member(5, "Ole Larsen", "ole@larsen.dk", "Larsen's vej", "12123434", "010190-1239", new DateTime(03012019), true);
            Member Sten = new Member(6, "Sten Stensen", "sten@stensen.dk", "Sten's vej", "56567878", "040180-1111", new DateTime(03052017), true);
            Member Børge = new Member(7, "Børge Stensen", "børge@stensen.dk", "Sten's vej", "56567979", "040180-1109", new DateTime(03062017), true);
            Member Sten1 = new Member(8, "Sten Stensen", "sten@hæren.dk", "Sten's fort", "55555501", "010179-5501", new DateTime(03052020), true);
            Member Sten2 = new Member(9, "Sten Stensen", "sten@hæren.dk", "Sten's fort", "55555502", "010179-5503", new DateTime(04052017), false);
            Member Sten3 = new Member(10, "Sten Stensen", "sten@hæren.dk", "Sten's fort", "55555503", "010179-5505", new DateTime(05052017), true);
            Member Sten4 = new Member(11, "Sten Stensen", "sten@hæren.dk", "Sten's fort", "55555504", "010179-5507", new DateTime(06052017), false);
            Member Sten5 = new Member(12, "Sten Stensen", "sten@hæren.dk", "Sten's fort", "55555505", "010179-5509", new DateTime(07052017), true);
            Member Sten6 = new Member(13, "Sten Stensen", "sten@hæren.dk", "Sten's fort", "55555506", "010179-5511", new DateTime(08052017), false);
            Member Sten7 = new Member(14, "Sten Stensen", "sten@hæren.dk", "Sten's fort", "55555507", "010179-5513", new DateTime(09052017), true);
            Member Sten8 = new Member(15, "Sten Stensen", "sten@hæren.dk", "Sten's lejr", "55555508", "010179-5515", new DateTime(10052017), false);
            Member Sten9 = new Member(16, "Sten Stensen", "sten@hæren.dk", "Sten's lejr", "55555509", "010179-5517", new DateTime(11052017), true);
            Member Sten10 = new Member(17, "Sten Stensen", "sten@hæren.dk", "Sten's slot", "55555510", "010179-5519", new DateTime(12052017), false);
            Member Sten11 = new Member(18, "Sten Stensen", "sten@hæren.dk", "Sten's slot", "55555511", "010179-5521", new DateTime(13052017), true);
            Member Sten12 = new Member(19, "Sten Stensen", "sten@hæren.dk", "Sten's slot", "55555512", "010179-5523", new DateTime(14052017), false);
            Member Sten13 = new Member(20, "Sten Stensen", "sten@hæren.dk", "Sten's slot", "55555513", "010179-5525", new DateTime(15052017), true);
            Member Sten14 = new Member(21, "Sten Stensen", "sten@hæren.dk", "Sten's slot", "55555514", "010179-5527", new DateTime(16052017), false);
            Member Sten15 = new Member(22, "Sten Stensen", "sten@hæren.dk", "Sten's slot", "55555515", "010179-5529", new DateTime(17052017), true);

            List<Member> members = new List<Member>();

            members.Add(Giocomo);
            members.Add(Hans);
            members.Add(Lars);
            members.Add(Per);
            members.Add(Ole);
            members.Add(Sten);
            members.Add(Børge);
            members.Add(Sten1);
            members.Add(Sten2);
            members.Add(Sten3);
            members.Add(Sten4);
            members.Add(Sten5);
            members.Add(Sten6);
            members.Add(Sten7);
            members.Add(Sten8);
            members.Add(Sten9);
            members.Add(Sten10);
            members.Add(Sten11);
            members.Add(Sten12);
            members.Add(Sten13);
            members.Add(Sten14);
            members.Add(Sten15);

            return Task.FromResult(members);
        }

    }
}