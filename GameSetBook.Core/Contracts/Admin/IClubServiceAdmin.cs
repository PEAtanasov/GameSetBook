﻿using GameSetBook.Core.Models.Admin.Club;
using System.Threading.Tasks;

namespace GameSetBook.Core.Contracts.Admin
{
    public interface IClubServiceAdmin
    {
        Task<IEnumerable<PendingClubViewModel>> AllPendingClubsAsync();

        Task<ClubDetailsAdminViewModel> GetPendingClubDetailsAsync(int id);

        Task<ClubDetailsAdminViewModel> GetClubDetailsAsync(int id);

        Task<ClubEditFormModel> GetClubForEditAsync(int id);

        Task EditAsync(ClubEditFormModel model);

        Task<bool> ExistAsync(int id);

        Task<bool> IsDeletedAsync(int id);

        Task<bool> ExistByNameAsync(string name);

        Task<bool> ExsitAnotherClubWhitNameAsync(int id, string name);

        Task<bool> IsClubApprovedAsync(int id);

        Task<string> ApproveAsync(int id);

        Task DeleteAsync(int id);

        Task HardDeleteAsync(int id);

        Task<AllClubsAdminSortingModel> GetClubSortingModelAsync(AllClubsAdminSortingModel model);

        Task<string> GetClubNameAsync(int clubId);

        Task<ClubHardDeleteAdminServiceModel> GetHardDeleteModelAsync(int id);

        Task CreateAsync(ClubAdminCreateFormModel model);

        Task<int> GetClubIdByNameAsync(string name);

        public Task<ClubScheduleAdminServiceModel> GetClubScheduleModelAsync(int id, DateTime date);

        Task<ClubMenuViewModel> GetClubMenuAsync(int id);
    }
}
