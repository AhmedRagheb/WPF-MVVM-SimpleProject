using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Windows.Input;

using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;

namespace CompanyProjectWPF.Controls
{
        

        /// <summary>
        /// Utility class that helps coordinate paged access to a data store.
        /// </summary>
        public sealed class PagingController : NotificationObject
        {
            /// <summary>
            /// The count of items to be divided into pages.
            /// </summary>
            private int _itemCount;

            /// <summary>
            /// The current page.
            /// </summary>
            private int _currentPage;

            /// <summary>
            /// The length (number of items) of each page.
            /// </summary>
            private int _pageSize;

            /// <summary>
            /// Initializes a new instance of the <see cref="PagingController"/> class.
            /// </summary>
            /// <param name="itemCount">The item count.</param>
            /// <param name="pageSize">The size of each page.</param>
            public PagingController(int itemCount, int pageSize)
            {
                Contract.Requires(itemCount >= 0);
                Contract.Requires(pageSize > 0);

                this._itemCount = itemCount;
                this._pageSize = pageSize;
                this._currentPage = this._itemCount == 0 ? 0 : 1;

                this.GotoFirstPageCommand = new DelegateCommand(() => this.CurrentPage = 1, () => this.ItemCount != 0 && this.CurrentPage > 1);
                this.GotoLastPageCommand = new DelegateCommand(() => this.CurrentPage = this.PageCount, () => this.ItemCount != 0 && this.CurrentPage < this.PageCount);
                this.GotoNextPageCommand = new DelegateCommand(() => ++this.CurrentPage, () => this.ItemCount != 0 && this.CurrentPage < this.PageCount);
                this.GotoPreviousPageCommand = new DelegateCommand(() => --this.CurrentPage, () => this.ItemCount != 0 && this.CurrentPage > 1);
            }

            /// <summary>
            /// Occurs when the value of <see cref="CurrentPage"/> changes.
            /// </summary>
            public event EventHandler<CurrentPageChangedEventArgs> CurrentPageChanged;

            /// <summary>
            /// Gets the command that, when executed, sets <see cref="CurrentPage"/> to 1.
            /// </summary>
            /// <value>The command that changes the current page.</value>
            public ICommand GotoFirstPageCommand { get; private set; }

            /// <summary>
            /// Gets the command that, when executed, decrements <see cref="CurrentPage"/> by 1.
            /// </summary>
            /// <value>The command that changes the current page.</value>
            public ICommand GotoPreviousPageCommand { get; private set; }

            /// <summary>
            /// Gets the command that, when executed, increments <see cref="CurrentPage"/> by 1.
            /// </summary>
            /// <value>The command that changes the current page.</value>
            public ICommand GotoNextPageCommand { get; private set; }

            /// <summary>
            /// Gets the command that, when executed, sets <see cref="CurrentPage"/> to <see cref="PageCount"/>.
            /// </summary>
            /// <value>The command that changes the current page.</value>
            public ICommand GotoLastPageCommand { get; private set; }

            /// <summary>
            /// Gets or sets the total number of items to be divided into pages.
            /// </summary>
            /// <value>The item count.</value>
            public int ItemCount
            {
                get
                {
                    return this._itemCount;
                }

                set
                {
                    Contract.Requires(value >= 0);

                    this._itemCount = value;
                    this.RaisePropertyChanged(() => this.ItemCount);
                    this.RaisePropertyChanged(() => this.PageCount);
                    RaiseCanExecuteChanged(this.GotoLastPageCommand, this.GotoNextPageCommand);

                    if (this.CurrentPage > this.PageCount)
                    {
                        this.CurrentPage = this.PageCount;
                    }
                }
            }

            /// <summary>
            /// Gets or sets the number of items that each page contains.
            /// </summary>
            /// <value>The size of the page.</value>
            public int PageSize
            {
                get
                {
                    return this._pageSize;
                }

                set
                {
                    Contract.Requires(value > 0);

                    var oldStartIndex = this.CurrentPageStartIndex;
                    this._pageSize = value;
                    this.RaisePropertyChanged(() => this.PageSize);
                    this.RaisePropertyChanged(() => this.PageCount);
                    this.RaisePropertyChanged(() => this.CurrentPageStartIndex);
                    RaiseCanExecuteChanged(this.GotoLastPageCommand, this.GotoNextPageCommand);

                    if (oldStartIndex >= 0)
                    {
                        this.CurrentPage = this.GetPageFromIndex(oldStartIndex);
                    }
                }
            }

            /// <summary>
            /// Gets the number of pages required to contain all items.
            /// </summary>
            /// <value>The page count.</value>
            public int PageCount
            {
                get
                {
                    Contract.Ensures(Contract.Result<int>() == 0 || this._itemCount > 0);
                    Contract.Ensures(Contract.Result<int>() > 0 || this._itemCount == 0);

                    if (this._itemCount == 0)
                    {
                        return 0;
                    }

                    var ceil = (int)Math.Ceiling((double)this._itemCount / this._pageSize);

                    Contract.Assume(ceil > 0); // Math.Ceiling makes the static checker unable to prove the postcondition without help
                    return ceil;
                }
            }

            /// <summary>
            /// Gets or sets the current page.
            /// </summary>
            /// <value>The current page.</value>
            public int CurrentPage
            {
                get
                {
                    return this._currentPage;
                }

                set
                {
                    Contract.Requires(value == 0 || this.PageCount != 0);
                    Contract.Requires(value > 0 || this.PageCount == 0);
                    Contract.Requires(value <= this.PageCount);

                    this._currentPage = value;
                    this.RaisePropertyChanged(() => this.CurrentPage);
                    this.RaisePropertyChanged(() => this.CurrentPageStartIndex);
                    RaiseCanExecuteChanged(this.GotoLastPageCommand, this.GotoNextPageCommand);
                    RaiseCanExecuteChanged(this.GotoFirstPageCommand, this.GotoPreviousPageCommand);

                    var handler = this.CurrentPageChanged;
                    if (handler != null)
                    {
                        handler(this, new CurrentPageChangedEventArgs(this.CurrentPageStartIndex, this.PageSize));
                    }
                }
            }

            /// <summary>
            /// Gets the index of the first item belonging to the current page.
            /// </summary>
            /// <value>The index of the first item belonging to the current page.</value>
            public int CurrentPageStartIndex
            {
                get
                {
                    Contract.Ensures(Contract.Result<int>() == -1 || this.PageCount != 0);
                    Contract.Ensures(Contract.Result<int>() >= 0 || this.PageCount == 0);
                    Contract.Ensures(Contract.Result<int>() < this.ItemCount);
                    return this.PageCount == 0 ? -1 : (this.CurrentPage - 1) * this.PageSize;
                }
            }

            /// <summary>
            /// Calls RaiseCanExecuteChanged on any number of DelegateCommand instances.
            /// </summary>
            /// <param name="commands">The commands.</param>
            [Pure]
            private static void RaiseCanExecuteChanged(params ICommand[] commands)
            {
                Contract.Requires(commands != null);
                foreach (var command in commands.Cast<DelegateCommand>())
                {
                    command.RaiseCanExecuteChanged();
                }
            }

            /// <summary>
            /// Gets the number of the page to which the item with the specified index belongs.
            /// </summary>
            /// <param name="itemIndex">The index of the item in question.</param>
            /// <returns>The number of the page in which the item with the specified index belongs.</returns>
            [Pure]
            private int GetPageFromIndex(int itemIndex)
            {
                Contract.Requires(itemIndex >= 0);
                Contract.Requires(itemIndex < this._itemCount);
                Contract.Ensures(Contract.Result<int>() >= 1);
                Contract.Ensures(Contract.Result<int>() <= this.PageCount);

                var result = (int)Math.Floor((double)itemIndex / this.PageSize) + 1;
                Contract.Assume(result >= 1); // Math.Floor makes the static checker unable to prove the postcondition without help
                Contract.Assume(result <= this.PageCount); // Ditto
                return result;
            }

            /// <summary>
            /// Defines the invariant for object of this class.
            /// </summary>
            [ContractInvariantMethod]
            private void ObjectInvariant()
            {
                Contract.Invariant(this._currentPage == 0 || this.PageCount != 0);
                Contract.Invariant(this._currentPage > 0 || this.PageCount == 0);
                Contract.Invariant(this._currentPage <= this.PageCount);
                Contract.Invariant(this._pageSize > 0);
                Contract.Invariant(this._itemCount >= 0);
            }
        }
    }

