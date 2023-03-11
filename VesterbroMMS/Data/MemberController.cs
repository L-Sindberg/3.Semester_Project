using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using VesterbroMMS.Model;
using VesterbroMMS.Model.Observers;
using VesterbroMMS.Services;
using System.Threading;

namespace VesterbroMMS.Data
{
    public class MemberController : ControllerBase
    {
        private List<Member> _members;
        private bool _sortWay = true;
        private string _latestSort = "none";
        private List<int> _selectedMemberIds = new List<int>();
        private readonly MemberService _memberService;
        public MembersTracker MembersTracker { get; private set; }

        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
            MembersTracker = new MembersTracker();
        }

        public async Task Initialize()
        {
            _members = await _memberService.AcquireMembers();
            MembersTracker.TrackMembers(_members);
        }

        public int GetFirstSelectedID()
        {
            return _selectedMemberIds[0];
        }

        public List<int> GetSelectedmemberslist()
        {
            return _selectedMemberIds;
        }

        public void ClearSelectedmemberslist()
        {
            _selectedMemberIds.Clear();
        }

        public void Sort(string method)
        {
            if (method == _latestSort)
            {
                _members.Sort(new MemberComparer(method, _sortWay));
                _sortWay = false;
            }
            else
            {
                _members.Sort(new MemberComparer(method));
                _sortWay = true;
            }

            _latestSort = method;
            MembersTracker.TrackMembers(_members);
        }

        public void SelectMember(int id)
        {
            if (_selectedMemberIds.Contains(id))
            {
                _selectedMemberIds.Remove(id);
            } else
            {
                _selectedMemberIds.Add(id);
            }
        }

        public int NumberOfSelectedMembers()
        {
            return _selectedMemberIds.Count;
        }

        public void AddMember(Member newMember)
        {
            Console.WriteLine(newMember);
        }

        public Member GetMemberById(int id)
        {
            foreach(Member member in _members) {
                if(member.Id == id)
                {
                    return member;
                }
            }

            return default;
        }

        public bool IsMemberSelected(int id)
        {
            return _selectedMemberIds.Contains(id);
        }
    }
}
